﻿-- Kehoachdieutri duoc tao -> mac dinh thanh toan duoc tao voi tiencanthanhtoan = 0 
-- -> insert các giai doan điều trị -> cập nhật tiên cân thanh toán  (PASS)
create or alter trigger rb_TienCanThanhToan_THANHTOAN on GIAIDOAN
for insert, update
as
begin
	if not exists(select * from KEHOACHDIEUTRI KHDT, inserted ins where 
	ins.MaBenhAn = khdt.MaBenhAn and  ins.MaRangKham = KHDT.MaRangKham 
	AND KHDT.TrangThaiDieuTri = N'kế hoạch')
	begin
		--print N'Kế hoạch điều trị này chưa được tạo hoặc chưa có trạng thái hoặc đã hoàn thành hoặc đã bị hủy'
		return
	end
	declare @total int
	declare @mathanhtoan int 

	-- tính tổng phí điều trị thêm vào của một kết hoạch điều trị
	select @total = sum(dt.phidieutri) from inserted ins, dieutri dt
	where ins.madieutri = dt.madieutri


	update THANHTOAN SET TienCanThanhToan = TienCanThanhToan + @TOTAL  
	FROM THANHTOAN TT, KEHOACHDIEUTRI KHDT, inserted ins
	WHERE ins.MaBenhAn = khdt.MaBenhAn and  ins.MaRangKham = KHDT.MaRangKham 
	and TT.MaThanhToan = KHDT.MaThanhToan
end
go

-- mỗi khi thanh toán được thêm hoặc cập nhật thì nó sẽ tính lại hết tổng tiền điều trị trong hosobenhnhan (PASS)
create or alter trigger rb_TongTienDieuTri_HSBN on THANHTOAN
for insert, update
as
begin
	if not exists(select * from KEHOACHDIEUTRI KHDT, inserted ins where 
	ins.MaThanhToan = khdt.mathanhtoan AND KHDT.TrangThaiDieuTri = N'kế hoạch')
	begin
		--print N'Kế hoạch điều trị này chưa được tạo hoặc chưa có trạn thái hoặc đã hoàn thành hoặc đã bị hủy'
		return
	end

	declare @total int
	declare @mahsba int
	select @mahsba = khdt.mabenhan from KEHOACHDIEUTRI khdt, inserted ins where ins.MaThanhToan = khdt.MaThanhToan

	select @total = sum(tt.tiencanthanhtoan) from KEHOACHDIEUTRI khdt, THANHTOAN tt 
	where khdt.MaThanhToan = tt.MaThanhToan and khdt.MaBenhAn = @mahsba 
	update HOSOBENHNHAN SET TongTienDieuTri = @total where @mahsba = MaBenhAn
end
go

-- khi ma trạng thái điều trị được update thành 'đã hoàn thành' nó sẽ tính lại tổng tiền thanh toán trong bảng hồ sơ bệnh nhân 
create or alter trigger rb_TongTienThanhToan_HSBN on KEHOACHDIEUTRI
for insert, update
as
begin
	if update(TRANGTHAIDIEUTRI)
	begin 
			declare @state nvarchar(50)
			select @state = ins.trangthaidieutri from inserted ins
			if @state = N'đã hoàn thành'
			begin
				declare @mahsba int
				select @mahsba = ins.mabenhan from inserted ins

				declare @total bigint
				select @total = sum(tt.tiencanthanhtoan) from THANHTOAN tt , KEHOACHDIEUTRI khdt
				where tt.MaThanhToan = khdt.mathanhtoan and khdt.MaBenhAn = @mahsba and khdt.TrangThaiDieuTri = N'đã hoàn thành'

				update HOSOBENHNHAN set TongTienThanhToan = @total where @mahsba = MaBenhAn
			end 
	end 
end
go


-- khi nha sĩ và nhân viên thay đổi số điện thoại thì cập nhật lại tên đăng nhập của tài khoản luôn
CREATE OR ALTER TRIGGER CapNhatTenDangNhap_NS
ON NHASI
AFTER UPDATE
AS
BEGIN
    IF UPDATE(DienThoaiNS)
    BEGIN
        UPDATE TK
        SET TK.TenDangNhap = i.DienThoaiNS
        FROM TAIKHOAN TK
        JOIN inserted i ON TK.MaTaiKhoan = i.MaNhaSi
        WHERE TK.MaTaiKhoan IN (SELECT i.MaNhaSi FROM inserted i)
    END
END
GO

CREATE OR ALTER TRIGGER CapNhatTenDangNhap_NV
ON NHANVIEN
AFTER UPDATE
AS
BEGIN
    IF UPDATE(DienThoaiNV)
    BEGIN
        UPDATE TK
        SET TK.TenDangNhap = i.DienThoaiNV
        FROM TAIKHOAN TK
        JOIN inserted i ON TK.MaTaiKhoan = i.MaNhanVien
        WHERE TK.MaTaiKhoan IN (SELECT i.MaNhanVien FROM inserted i)
    END
END
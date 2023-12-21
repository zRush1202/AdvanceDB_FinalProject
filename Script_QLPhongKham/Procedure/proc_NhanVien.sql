use CSDLNC_QLPhongKham
go

-- NHÂN VIÊN: Duyệt cuộc hẹn yêu cầu của bệnh nhân
create or alter proc sp_DuyetCHYC @machyc int, @manvql int
as
begin
	if not exists(select * from CH_YEUCAU where MaCHYC = @machyc)
	begin
		print N'Mã cuộc hẹn yêu cầu không tồn tại' 
		return -- không tồn tại tại CHYC này
	end
	-- Lấy mã bệnh nhân
	declare @mabn int
	select @mabn = MaBenhNhan
	from CH_YEUCAU
	where @machyc = MaCHYC

	-- trường hợp bệnh nhân mới
	if not exists (select * from HOSOBENHNHAN where MaBenhNhan = @mabn)
	begin 
		insert into HOSOBENHNHAN(TongTienDieuTri, TongTienThanhToan, MaBenhNhan, MaNVQL) values (0,0, @mabn, @manvql)
		print N'Đã lập hồ sơ cho bệnh nhân này'
	end
	delete from CH_YEUCAU where MaCHYC = MaCHYC
	return
end

go
-- NHÂN VIÊN: Xóa cuộc hẹn yêu cầu của bệnh nhân
create or alter proc sp_XoaCHYC @machyc int
as
begin
	if not exists(select * from CH_YEUCAU where MaCHYC = @machyc)
	begin
		print N'Mã cuộc hẹn yêu cầu không tồn tại'
		return
	end

	delete from CH_YEUCAU where MaCHYC = @machyc
end
go


-- NHÂN VIÊN: Tạo cuộc hẹn với nha sĩ cho bệnh nhân
-- NHÂN VIÊN: Tạo kế hoạch điều trị cho bệnh nhân


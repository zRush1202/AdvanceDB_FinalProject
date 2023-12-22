use CSDLNC_QLPhongKham
go


-- NHA SĨ: cập nhật hồ sơ bẹnh nhân
create or alter proc sp_capNhatHoSoBenhNhan @mabenhnhan int, @suckhoerang nvarchar(100), @tinhtrangdiung nvarchar(100)
as
begin
	if not exists (select * from BENHNHAN where @mabenhnhan = MaBenhNhan)
		begin
			print N'Không tồn tại bệnh nhân này'
			return 
		end
	update HOSOBENHNHAN set SucKhoeRang = @suckhoerang, TinhTrangDiUng = @tinhtrangdiung 
	where MaBenhNhan = @mabenhnhan 
	print N'Cập nhật hồ sơ bệnh nhân thành công'
	return 
end
go
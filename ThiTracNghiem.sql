CREATE DATABASE THITRACNHGIEM
GO

USE THITRACNHGIEM
GO


-- tạo bảng KHOA
CREATE TABLE KHOA
(
	MAKHOA CHAR(10) PRIMARY KEY ,
	TENKHOA NVARCHAR(100) UNIQUE,
	
)


-- tạo bảng LOP
CREATE TABLE LOPHOC
(
	MALOP CHAR(10) PRIMARY KEY,
	TENLOP NVARCHAR(100) UNIQUE,
	MAKHOA CHAR(10) NOT NULL
	
)


-- tạo bảng sinh vien
CREATE TABLE SINHVIEN
(
	MASV VARCHAR(10) ,
	HOTEN NVARCHAR(40) NOT NULL,
	NGAYSINH DATE CHECK (NGAYSINH < GETDATE()),
	GIOITINH CHAR(3) CHECK(GIOITINH IN ('Nam','Nu')),
	NOISINH NVARCHAR(50),
	MALOP CHAR(10) NOT NULL
	
	CONSTRAINT PK_SINHVIEN_MASV PRIMARY KEY(MASV)
	
)

-- tạo bảng MONHOC
CREATE TABLE MONHOC
(
	MAMH CHAR(5) ,
	TenMH NVARCHAR(30) UNIQUE,
	SOTIET INT,
	MAKHOA CHAR(10) NOT NULL
	
	
	CONSTRAINT PK_MONHOC_MAMH PRIMARY KEY(MAMH)
)

-- tạo bảng GIAOVIEN
CREATE TABLE GIAOVIEN
(
	MAGV VARCHAR(10) PRIMARY KEY,
	TENGV NVARCHAR(90),
	NGAYSINH DATE CHECK(NGAYSINH < GETDATE()),
	GIOITINH CHAR(3) CHECK(GIOITINH IN ('Nam','Nu')),
	NOISINH NVARCHAR(50),
	MAMH CHAR(5) NOT NULL		
)

-- tạo bảng DETHI
CREATE TABLE DETHI
(
	MADT CHAR(5) PRIMARY KEY,
	THOIGIANTHI INT CHECK (THOIGIANTHI > 29 AND THOIGIANTHI < 31),
	SOCAUHOI INT CHECK (SOCAUHOI > 29 AND SOCAUHOI < 31),
	NGAYTHI CHAR(25)
)

-- TẠO BẢNG CAUHOI
CREATE TABLE CAUHOI
(
	ID INT PRIMARY KEY,
	NOIDUNGCAUHOI NVARCHAR(400),
	DAPAN1 NVARCHAR(400),
	DAPAN2 NVARCHAR(400),
	DAPAN3 NVARCHAR(400),
	DAPAN4 NVARCHAR(400),
	KETQUA1 CHAR(1),
	KETQUA2 CHAR(1),
	KETQUA3 CHAR(1),
	KETQUA4 CHAR(1),
	SOCAUDUNG CHAR(1), -- ví dụ: ketqua 1 dung thi là 1, kết quả 4 đúng thì là 4
)

-- Tạo bảng kết quả
CREATE TABLE KETQUA
(
	MASV VARCHAR(10) NOT NULL ,
	MAMH CHAR(5) NOT NULL,
	MADT CHAR(5) NOT NULL,
	LANTHI TINYINT NOT NULL,
	DIEM FLOAT CHECK(DIEM >= 0 AND DIEM <= 10),
	CAUDUNG INT CHECK( CAUDUNG >= 0 AND CAUDUNG <= 30),
	CAUSAI INT CHECK(CAUSAI >= 0 AND CAUSAI <= 30)	
	CONSTRAINT PK_MASV_LANTHI_MAMH PRIMARY KEY(LanThi,MASV,MAMH,MADT)
)



-- tạo khoa ngoại
ALTER TABLE dbo.KETQUA ADD CONSTRAINT FK_KETQUA_MASV FOREIGN KEY(MASV) REFERENCES dbo.SINHVIEN(MASV)
ALTER TABLE dbo.KETQUA ADD CONSTRAINT FK_KETQUA_MAMH FOREIGN KEY(MAMH) REFERENCES dbo.MONHOC(MAMH)
ALTER TABLE dbo.KETQUA ADD CONSTRAINT FK_KETQUA_MADT FOREIGN KEY(MADT) REFERENCES dbo.DETHI(MADT)
ALTER TABLE dbo.SINHVIEN ADD CONSTRAINT FK_SINHVIEN_MALOP FOREIGN KEY(MALOP) REFERENCES dbo.LOPHOC(MALOP)
ALTER TABLE dbo.LOPHOC ADD CONSTRAINT FK_LOPHOC_MAKHOA FOREIGN KEY(MAKHOA) REFERENCES dbo.KHOA(MAKHOA)
ALTER TABLE dbo.GIAOVIEN ADD CONSTRAINT FK_GIAOVIEN_MAMH FOREIGN KEY(MAMH) REFERENCES dbo.MONHOC(MAMH)
ALTER TABLE dbo.MONHOC ADD CONSTRAINT FK_MONHOC_MAKHOA FOREIGN KEY(MAKHOA) REFERENCES dbo.KHOA(MAKHOA)


						--------------------------------------------------------^^^--------------------------------------------------------


-- insert data bảng khoa
INSERT dbo.KHOA VALUES  ( 'QTKD', N'Quản Trị Kinh Doanh' )
INSERT dbo.KHOA VALUES  ( 'HTTT', N'Hệ thống thông tin và viễn thám' )
INSERT dbo.KHOA VALUES  ( 'ĐC', N'Địa Chất' )
INSERT dbo.KHOA VALUES  ( 'TN', N'Tài Nguyên' )


-- insert bảng MONHOC
INSERT dbo.MONHOC VALUES  ( '01', N'Bản Đồ Đại Cương', 45 , 'TN' )
INSERT dbo.MONHOC VALUES  ( '02', N'Cơ Sỡ Dữ Liệu', 45 , 'HTTT' )
INSERT dbo.MONHOC VALUES  ( '03', N'Tâm Lý Học', 30 , 'QTKD' )
INSERT dbo.MONHOC VALUES  ( '04', N'Lập Trình Web', 45 , 'HTTT' )
INSERT dbo.MONHOC VALUES  ( '05', N'Mạng Máy Tính', 30 , 'HTTT' )


-- insert bảng GIAOVIEN
INSERT dbo.GIAOVIEN VALUES  ( 'GV01' ,   N'Mai Thị Duyên' ,  '1989/05/24' , 'Nu' ,   N'Thanh Hóa' ,   '01'   )
INSERT dbo.GIAOVIEN VALUES  ( 'GV02' ,   N'Cao Hoàng Hải' ,  '1988/03/17' , 'Nam' ,   N'Long An' ,   '02'   )
INSERT dbo.GIAOVIEN VALUES  ( 'GV03' ,   N'Lâm Tâm Như' ,    '1988/02/07' , 'Nu' ,   N'TPHCM' ,   '03'   )
INSERT dbo.GIAOVIEN VALUES  ( 'GV04' ,   N'Cao Xuân Tài' ,  '1987/06/13' , 'Nam' ,   N'Kiên Giang' ,   '04'   )
INSERT dbo.GIAOVIEN VALUES  ( 'GV05' ,   N'Phan Tư Duy' ,  '1985/04/15' , 'Nam' ,   N'TPHCM' ,   '05'   )


-- INSERT DATA BẢNG LOPHOC
INSERT dbo.LOPHOC VALUES  ( 'CNTT',  N'Công nghệ thông tin',  'HTTT'  )
INSERT dbo.LOPHOC VALUES  ( 'CTN',  N'Cấp thoát nước',  'TN'  )
INSERT dbo.LOPHOC VALUES  ( 'HTTT',  N'Hệ thống thông tin',  'HTTT'  )
INSERT dbo.LOPHOC VALUES  ( 'ĐĐ',  N'Đo đạc',  'ĐC'  )
INSERT dbo.LOPHOC VALUES  ( 'QTKD',  N'Quản trị kinh doanh',  'QTKD'  )


-- insert dta bảng SINHVIEN
INSERT dbo.SINHVIEN VALUES  ( 'T01' , N'Trần Xuân Toàn' , '1999/02/12' , 'Nam' , N'Đà Nẵng' ,'ĐĐ' )
INSERT dbo.SINHVIEN VALUES  ( 'T02' , N'Hồ Thanh Nga' , '1998/05/24' , 'Nu' , N'Hà Nội' ,'QTKD' )
INSERT dbo.SINHVIEN VALUES  ( 'T03' , N'Bùi Tú Vy' , '2000/10/21' , 'Nu' , N'Hà Nội' ,'CNTT' )
INSERT dbo.SINHVIEN VALUES  ( 'T04' , N'Lê Mạnh Hùng' , '1997/01/02' , 'Nam' , N'Thanh Hóa' ,'CTN' )
INSERT dbo.SINHVIEN VALUES  ( 'T05' , N'Tống Mỹ Dung' , '1998/03/12' , 'Nu' , N'TPHCM' , 'HTTT' )
INSERT dbo.SINHVIEN VALUES  ( 'T06' , N'Nguyễn Hàn Lâm' , '1999/12/15' , 'Nam' , N'Ninh Thuận' ,'QTKD' )
INSERT dbo.SINHVIEN VALUES  ( 'T07' , N'Trương Minh Trí' , '2000/11/07' , 'Nam' ,N'TPHCM' , 'HTTT' )


-- insert data CAUHOI
INSERT dbo.CAUHOI VALUES  ( '1' , N'Câu 1. Phép chiếu hình bản đồ được dùng để:' , N'A. Biểu diễn mặt cong Trái Đất lên một mặt phẳng' ,  
 N'B. Thể hiện mạng lưới kinh vĩ tuyến' , N'C. Chiếu bề mặt Trái Đất lên hình trụ' , N'D. Ý A và B đúng' , 1 , 0 , 0 , 0 , '1' )
 
INSERT dbo.CAUHOI VALUES  ( '2' , N'Câu 2. Nhận định nào dưới đây là chưa chính xác về đặc điểm của bản đồ:' , N'A. Là hình ảnh thu nhỏ một phần hay toàn bộ bề mặt Trái Đất lên mặt phẳng trên cơ sở toán học nhất định' ,  
 N'B. Nội dung các hiện tượng, sự vật trên bản đồ đã được khái quát hoá' , N'C. Được trình bày bằng hệ thống kí hiệu bản đồ' , N'D. Là bức ảnh chụp một phần lãnh thổ trên Trái Đất' , 1 , 0 , 0 , 0 , '1' )
 
INSERT dbo.CAUHOI VALUES  ( '3' , N'Câu 3. Nguyên nhân cơ bản khiến chúng ta phải sử dụng nhiều phép chiếu đồ khác nhau là:' , N'A. Do bề mặt Trái Đất cong' ,  
 N'B. Do yêu cầu sử dụng khác nhau' , N'C. Do vị trí lãnh thổ cần thể hiện' , N'D. Do hình dáng lãnh thổ' , 0 , 1 , 0 , 0 , '2' )
 
INSERT dbo.CAUHOI VALUES  ( '4' , N'Câu 4. Mặt phẳng chiếu đồ thường có dạng hình học là :' , N'A. Hình nón' ,  
 N'B. Hình trụ' , N'C. Mặt phẳng' , N'D. Tất cả các ý trên' , 0 , 0 , 0 , 1 , '4' )
 
INSERT dbo.CAUHOI VALUES  ( '5' , N'Câu 5. Cơ sở để phân chia thành các loại phép chiếu: phương vị, hình nón, hình trụ là:' , N'A. Do vị trí lãnh thổ cần thể hiện' ,  
 N'B. Do hình dạng mặt chiếu' , N'C. Do vị trí tiếp xúc mặt chiếu' , N'D. Do đặc điểm lưới chiếu' , 0 , 1 , 0 , 0 , '2' )
 
INSERT dbo.CAUHOI VALUES  ( '6' , N'Câu 6. Cơ sở để phân chia mỗi phép chiếu thành 3 loại: đứng, ngang, nghiêng là:' , N'A. Do vị trí tiếp xúc của mặt chiếu với Địa cầu' ,  
 N'B. Do hình dạng mặt chiếu' , N'C. Do vị trí lãnh thổ cần thể hiện' , N'D. Do đặc điểm lưới chiếu' , 0 , 0 , 0 , 1 , '4' )
 
INSERT dbo.CAUHOI VALUES  ( '7' , N'Câu 7. Phép chiếu phương vị sử dụng mặt chiếu đồ là:' , N'A. Hình nón' ,  
 N'B. Mặt phẳng' , N'C. Hình trụ' , N'D. Hình lục lăng' , 0 , 1 , 0 , 0 , '2' )
 
INSERT dbo.CAUHOI VALUES  ( '8' , N'Câu 8. Trong phép chiếu phương vị đứng mặt chiếu tiếp xúc với Địa cầu ở vị trí:' , N'A. Cực' ,  
 N'B. Vòng cực' , N'C. Chí tuyến' , N'D. Xích đạo' , 1 , 0 , 0 , 0 , '1' )
 
INSERT dbo.CAUHOI VALUES  ( '9' , N'Câu 9. Tính chính xác trong phép chiếu phương vị đứng có đặc điểm:' , N' A. Tăng dần từ vùng vĩ độ thấp lên vĩ độ cao' ,  
 N'   B. Cao ở vòng cực và giảm dần về hai phía' , N'C. Cao ở cực và giảm dần về các vĩ độ thấp hơn',
 N'D. Không đổi trên toàn bộ lãnh thổ thể hiện' , 0 , 0 , 1 , 0 , '3' )

INSERT dbo.CAUHOI VALUES  ( '10' , N'Câu 10. Phép chiếu phương vị ngang thường được dùng để vẽ bản đồ:' , N' A. Bán cầu Đông và bán cầu Tây' ,  
 N' B. Bán cầu Bắc và bán cầu Nam' , N' C. Vùng cực' , N' D. Vùng vĩ độ trung bình' , 1 , 0 , 0 , 0 , '1' )

INSERT dbo.CAUHOI VALUES  ( '11' , N'Câu 11. Tính chính xác trong phép chiếu phương vị nghiêng có đặc điểm:' , N'A. Cao ở vị trí tiếp xúc với mặt chiếu và giảm dần khi càng xa điểm tiếp xúc đó' ,  
 N'B. Cao ở kinh tuyến giữa và giảm dần về hai phía Đông  -  Tây' , N' C. Cao ở xích đạo và giảm dần về hai phía Bắc  -  Nam', N'D. Cao ở vĩ độ tiếp xúc với mặt chiếu và giảm  dần khi xa vĩ độ đó' , 1 , 0 , 0 , 0 , '1' )

INSERT dbo.CAUHOI VALUES  ( '12' , N'Câu 12. Phép chiếu phương vị nghiêng thường được dùng để vẽ bản đồ:' , N' A. Bán cầu Đông và bán cầu Tây' ,  
 N' B. Bán cầu Bắc và bán cầu Nam' , N'C. Vùng cực' , N'D. Vùng vĩ độ trung bình' , 1 , 0 , 0 , 0 , '1' )

INSERT dbo.CAUHOI VALUES  ( '13' , N'Câu 13. Trong số các phép chiếu phương vị, phép chiếu có khả năng thể hiện phần lãnh thổ ở xích đạo với độ chính xác lớn nhất là:' , N' A. Phương vị đứng' ,  
 N'B. Phương vị ngang' , N'C. Phương vị nghiêng' , N'D. Tất cả các phép chiếu trên' , 1 , 0 , 0 , 0 , '1' )

INSERT dbo.CAUHOI VALUES  ( '14' , N'Câu 14. Phương pháp kí hiệu đường chuyển động thường được dùng để thể hiện các đối tượng địa lí:' , N'A. Có sự phân bố theo những điểm cụ thể' ,  
 N'B. Có sự di chuyển theo các tuyến' , N'C. Có sự phân bố theo tuyến' , N'D. Có sự phân bố rải rác' , 0 , 1 , 0 , 0 , '2' )

INSERT dbo.CAUHOI VALUES  ( '15' , N'Câu 15. Phép chiếu hình nón đứng thường được sử dụng để vẽ những phần lãnh thổ có đặc điểm:' , N'A. Nằm ở vĩ độ trung bình, kéo dài theo chiều Bắc  -  Nam' ,  
 N'B. Nằm ở vĩ độ trung bình, kéo dài theo chiều Đông  -  Tây' , N'C. Nằm ở vĩ độ thấp, kéo dài theo chiều Đông  -  Tây' , N'D. Nằm ở vĩ độ cao, kéo dài theo chiều Đông  -  Tây' , 0 , 1 , 0 , 0 , '2' )

INSERT dbo.CAUHOI VALUES  ( '16' , N'Câu 16. Phép chiếu hình trụ đứng thường được sử dụng để vẽ những phần lãnh thổ có đặc điểm:' , N'  A. Nằm gần cực' ,  
 N'B. Nằm gần xích đạo' , N'C. Nằm gần vòng cực' , N'  D. Nằm ở vĩ độ trung bình' , 0 , 1 , 0 , 0 , '2' )

INSERT dbo.CAUHOI VALUES  ( '17' , N'Câu 17. Khi muốn thể hiện những phần lãnh thổ nằm ở vĩ độ trung bình với độ chính xác cao người ta dùng phép chiếu:' , N'A. Phương vị nghiêng' ,  
 N'B. Hình nón nghiêng' , N'C. Hình trụ nghiêng' , N'D. Tất cả các ý trên' , 0 , 0 , 1 , 0 , '3' )

INSERT dbo.CAUHOI VALUES  ( '18' , N'Câu 18. Khi muốn thể hiện những phần lãnh thổ nằm ở vùng cực với độ chính xác cao người ta dùng phép chiếu:' , N'A. Phương vị đứng' ,  
 N'B. Phương vị ngang' , N' C. Hình nón đứng' , N'D. Hình trụ đứng' , 0 , 0 , 0 , 1 , '4' )

INSERT dbo.CAUHOI VALUES  ( '19' , N'Câu 19. Bản đồ tỉ lệ lớn là loại bản đồ có tỉ lệ:' , N'A. ≥ 1: 200 000' ,  
 N'B. > 1: 200 000' , N'C. ≥ 1: 100 000' , N'D. ≤ 1:200 000' , 0 , 0 , 1 , 0 , '3' )

INSERT dbo.CAUHOI VALUES  ( '20' , N'Câu 20. Bản đồ tỉ lệ lớn là loại bản đồ có tỉ lệ:' , N'A. ≥ 1: 200 000' ,  
 N'B. > 1: 200 000' , N'C. ≥ 1: 100 000' , N'D. ≤ 1:200 000' , 0 , 0 , 1 , 0 , '3' )

INSERT dbo.CAUHOI VALUES  ( '21' , N'Câu 21. Bản đồ giáo khoa là loại bản đồ được phân loại dựa theo:' , N'A. Tỉ lệ bản đồ' ,  
 N'B. Phạm vi lãnh thổ' , N'C. Mục đích sử dụng' , N'D. Ý A và B đúng' , 0 , 0 , 1 , 0 , '3' )

INSERT dbo.CAUHOI VALUES  ( '22' , N'Câu 22. Phương pháp kí hiệu thường được dùng để thể hiện các đối tượng địa lí có đặc điểm:' , N'A. Phân bố với phạm vi trải rộng' ,  
 N' B. Phân bố theo những điểm cụ thể' , N'C. Phân bố theo dải' , N'D. Phân bố không đồng đều' , 0 , 1 , 0 , 0 , '2' )

INSERT dbo.CAUHOI VALUES  ( '23' , N'Câu 23. Các đối tượng địa lí nào sau đây thường được biểu hiện bằng phương pháp kí hiệu:' , N'A. Các đường ranh giới hành chính' ,  
 N'B. Các hòn đảo' , N'C. Các điểm dân cư' , N'D. Các dãy núi' , 0 , 1 , 0 , 0 , '2' )

INSERT dbo.CAUHOI VALUES  ( '24' , N'Câu 24. Các dạng kí hiệu thường được sử dụng trong phương pháp kí hiệu là:' , N'A. Hình học' ,  
 N'B. Chữ' , N'C. Tượng hình' , N'D. Tất cả các ý trên' , 0 , 0 , 0 , 1 , '4' )

INSERT dbo.CAUHOI VALUES  ( '25' , N'Câu 25. Trong phương pháp kí hiệu, sự khác biệt về qui mô và số lượng các hiện tượng cùng loại thường được biểu hiện bằng' , N'A. Sự khác nhau về màu sắc kí hiệu' ,  
 N'B. Sự khác nhau về kích thước độ lớn kí hiệu' , N'C. Sự khác nhau về hình dạng kí hiệu' , N'D. Ý A và B đúng' , 0 , 0 , 0 , 1 , '4' )

INSERT dbo.CAUHOI VALUES  ( '26' , N'Câu 26. Trên bản đồ tự nhiên, các đối tượng địa lí thường được thể hiện bằng phương pháp đường chuyển động là:' , N' A. Hướng gió, các dãy núi…' ,  
 N'B. Dòng sông, dòng biển….' , N'C. Hướng gió, dòng biển…' , N'D. Tất cả các ý trên' , 0 , 0 , 0 , 1 , '4' )

INSERT dbo.CAUHOI VALUES  ( '27' , N'Câu 27. Phương pháp chấm điểm thường được dùng để thể hiện các đối tượng địa lí có đặc điểm:' , N'A. Phân bố phân tán, lẻ tẻ' ,  
 N'B. Phân bố tập trung theo điểm' , N'C. Phân bố theo tuyến' , N'D. Phân bố ở phạm vi rộng' , 1 , 0 , 0 , 0 , '1' )

INSERT dbo.CAUHOI VALUES  ( '28' , N'Câu 28. Phương pháp khoanh vùng thường được dùng để thể hiện các đối tượng địa lí có đặc điểm:' , N'A. Phân bố tập trung theo điểm' ,  
 N'B. Không phân bố trên khắp lãnh thổ mà chỉ phát triển ở những khu vực nhất định' , N'C. Phân bố ở phạm vi rộng' , N'D. Phân bố phân tán, lẻ tẻ' , 0 , 1 , 0 , 0 , '2' )

INSERT dbo.CAUHOI VALUES  ( '29' , N'Câu 29. Đặc trưng của phương pháp khoanh vùng là:' , N'A. Thể hiện được sự phân bố của các đối tượng địa lí' ,  
 N'B. Thể hiện được động lực phát triển của các đối tượng' , N'C. Thể hiện sự phổ biến của một loại đối tượng riêng lẻ, dường như tách ra với các loại đối tượng khác' , N'D. Ý B và C đúng' , 0 , 0 , 0 , 1 , '4' )

INSERT dbo.CAUHOI VALUES  ( '30' , N'Câu 30. Phương pháp bản đồ  -  biểu đồ thường được dùng để thể hiện:' , N'A. Chất lượng của một hiện tượng địa lí trên một đơn vị lãnh thổ' ,  
 N'B. Giá trị tổng cộng của một hiện tượng địa lí trên một đơn vị lãnh thổ' , N'C. Cơ cấu giá trị của một hiện tượng địa lí trên một đơn vị lãnh thổ' , N'D. Động lực phát triển của một hiện tượng địa lí trên một đơn vị lãnh thổ' , 0 , 0 , 1 , 0 , '3' )

INSERT dbo.CAUHOI VALUES  ( '31' , N'Câu 31. Để thể hiện các mỏ than trên lãnh thổ nước ta người ta thường dùng phương pháp:' , N'A. Kí hiệu đường chuyển động' ,  
 N'B. Vùng phân bố' , N'C. Kí hiệu' , N'D. Chấm điểm' , 0 , 0 , 1 , 0 , '3' )

INSERT dbo.CAUHOI VALUES  ( '32' , N'Câu 32. Để thể hiện số lượng đàn bò của các tỉnh ở nước ta người ta thường dùng phương pháp:' , N'A. Kí hiệu' ,  
 N'B. Chấm điểm' , N'C. Bản đồ  -  biểu đồ' , N'D. Vùng phân bố' , 0 , 1 , 0 , 0 , '2' )

INSERT dbo.CAUHOI VALUES  ( '33' , N'Câu 33. Để thể hiện qui mô các đô thị lớn ở nước ta người ta thường dùng phương pháp:' , N'A. Kí hiệu' ,  
 N'B. Bản đồ  -  biểu đồ' , N'C. Vùng phân bố' , N'D. Chấm điểm' , 0 , 1 , 0 , 0 , '2' )

INSERT dbo.CAUHOI VALUES  ( '34' , N'Câu 34. Trong học tập, bản đồ là một phương tiện để học sinh:' , N'A. Học thay sách giáo khoa' ,  
 N'B. Học tập, rèn luyện các kĩ năng địa lí' , N'C. Thư giãn sau khi học xong bài' , N'D. Xác định vị trí các bộ phận lãnh thổ học trong bài' , 0 , 1 , 0 , 0 , '2' )

INSERT dbo.CAUHOI VALUES  ( '35' , N'Câu 35. Một trong những căn cứ rất quan trọng để xác định phương hướng trên bản đồ là dựa vào:' , N'A. Mạng lưới kinh vĩ tuyến thể hiện trên bản đồ' ,  
 N'B. Hình dáng lãnh thổ thể hiện trên bản đồ' , N'C. Vị trí địa lí của lãnh thổ thể hiện trên bản đồ' , N'D. Bảng chú giải' , 1 , 0 , 0 , 0 , '1' )


-- insert data bảng DETHI
INSERT dbo.DETHI VALUES  ( '12' ,30 ,  30 ,       '03/05/2019 08:30'   ) -- THI LẦN 1 01
INSERT dbo.DETHI VALUES  ( '21' ,30 ,  30 ,       '03/05/2019 08:30'   )

INSERT dbo.DETHI VALUES  ( '34' ,  30 ,   30 ,    '09/05/2019 09:30'   ) -- THI LẦN 1 02
INSERT dbo.DETHI VALUES  ( '43' ,  30 ,   30 ,    '09/05/2019 09:30'   )

INSERT dbo.DETHI VALUES  ( '56' ,   30 ,    30 ,  '13/05/2019 10:30'   ) -- THI LẦN 1 03
INSERT dbo.DETHI VALUES  ( '65' ,   30 ,    30 ,  '13/05/2019 10:30'   )

INSERT dbo.DETHI VALUES  ( '67' , 30 , 30 ,       '15/05/2019 13:30'    ) -- THI LẦN 1 04
INSERT dbo.DETHI VALUES  ( '76' , 30 , 30 ,       '15/05/2019 13:30'    )

INSERT dbo.DETHI VALUES  ( '78' ,   30 ,  30 ,    '20/05/2019 12:30'    ) -- THI LẦN 1 05
INSERT dbo.DETHI VALUES  ( '87' ,   30 ,  30 ,    '20/05/2019 12:30'    )

INSERT dbo.DETHI VALUES  ( 'AB' ,   30 ,  30 ,    '15/04/2020 07:30'    )-- THI LẠI LẦN 2 MAMON =1
INSERT dbo.DETHI VALUES  ( 'BA' ,   30 ,  30 ,    '15/04/2020 07:30'    )

INSERT dbo.DETHI VALUES  ( 'BC' , 30 ,   30 ,     '17/04/2020 08:30'    )-- THI LẠI LẦN 2 MAMON = 3
INSERT dbo.DETHI VALUES  ( 'CB' , 30 ,   30 ,     '17/04/2020 08:30'    )

INSERT dbo.DETHI VALUES  ( 'CD' , 30 ,   30 ,     '20/04/2020 10:30'    )-- THI LẠI LẦN 2 MAMON = 4
INSERT dbo.DETHI VALUES  ( 'DC' , 30 ,   30 ,     '20/04/2020 10:30'    )



-- inssert data bảng ketqua
INSERT dbo.KETQUA VALUES  ( 'T01' , '01' ,  '12' ,   1 ,   2 ,    6 ,   24 )
INSERT dbo.KETQUA VALUES  ( 'T01' , '01' ,  'AB' ,   2 ,   6 ,    18 ,  12 )
INSERT dbo.KETQUA VALUES  ( 'T01' , '02' ,  '34' ,   1 ,   6 ,    18 ,  12 )
INSERT dbo.KETQUA VALUES  ( 'T01' , '03' ,  '56' ,   1 ,   7 ,    21 ,  9  )
INSERT dbo.KETQUA VALUES  ( 'T01' , '03' ,  'CB' ,   2 ,   7 ,    21 ,  9  )
INSERT dbo.KETQUA VALUES  ( 'T01' , '05' ,  '78' ,   1 ,   5 ,    15 ,  15 )
INSERT dbo.KETQUA VALUES  ( 'T02' , '01' ,  '12' ,   1 ,   8 ,    24 ,  6  )
INSERT dbo.KETQUA VALUES  ( 'T02' , '02' ,  '43' ,   1 ,   6 ,    18 ,  12 )
INSERT dbo.KETQUA VALUES  ( 'T02' , '03' ,  '65' ,   1 ,   7 ,    21 ,  9  )
INSERT dbo.KETQUA VALUES  ( 'T03' , '01' ,  '21' ,   1 ,   6 ,    18 ,  12 )
INSERT dbo.KETQUA VALUES  ( 'T03' , '03' ,  '65' ,   1 ,   3 ,    9 ,   21 )
INSERT dbo.KETQUA VALUES  ( 'T03' , '03' ,  'BC' ,   2 ,   5 ,    15 ,  15 )
INSERT dbo.KETQUA VALUES  ( 'T04' , '05' ,  '78' ,   1 ,   10 ,    30 ,  0 )
INSERT dbo.KETQUA VALUES  ( 'T05' , '02' ,  '34' ,   1 ,   6 ,    18 ,  12 )
INSERT dbo.KETQUA VALUES  ( 'T05' , '04' ,  '76' ,   1 ,   7 ,    21 ,   9 )
INSERT dbo.KETQUA VALUES  ( 'T06' , '01' ,  '21' ,   1 ,   2 ,    6 ,   24 )
INSERT dbo.KETQUA VALUES  ( 'T06' , '01' ,  'AB' ,   2 ,   4 ,    12 ,  18 )
INSERT dbo.KETQUA VALUES  ( 'T06' , '04' ,  '67' ,   1 ,   1 ,    3 ,   27 )
INSERT dbo.KETQUA VALUES  ( 'T06' , '04' ,  'CD' ,   2 ,   3 ,    9 ,   21 )
INSERT dbo.KETQUA VALUES  ( 'T07' , '01' ,  '12' ,   1 ,   9 ,    27 ,  3  )
INSERT dbo.KETQUA VALUES  ( 'T07' , '02' ,  '34' ,   1 ,   8 ,    24 ,  6  )
INSERT dbo.KETQUA VALUES  ( 'T07' , '04' ,  '67' ,   1 ,   7 ,    21 ,  9  )


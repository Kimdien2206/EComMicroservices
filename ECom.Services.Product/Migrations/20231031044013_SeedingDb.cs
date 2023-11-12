using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECom.Services.Products.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "id", "discount_id", "name" },
                values: new object[,]
                {
                    { 1, null, "Thu - Đông" },
                    { 2, null, "Xuân - Hè" },
                    { 3, null, "Thể thao" },
                    { 4, null, "Bơi lội" }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "id", "discount_amount", "name" },
                values: new object[,]
                {
                    { 1, 5.0, "Hàng mới về" },
                    { 2, 15.0, "Hàng tồn kho" },
                    { 3, 20.0, "Hàng vải mới" }
                });

            migrationBuilder.InsertData(
                table: "HasTags",
                columns: new[] { "id", "product_id", "tag_id" },
                values: new object[,]
                {
                    { 1, 1, 6 },
                    { 2, 1, 7 },
                    { 3, 2, 10 },
                    { 4, 3, 3 },
                    { 5, 3, 4 },
                    { 6, 4, 7 },
                    { 7, 4, 6 },
                    { 8, 5, 6 },
                    { 9, 5, 7 },
                    { 10, 6, 5 },
                    { 11, 7, 9 },
                    { 12, 8, 5 },
                    { 13, 9, 4 },
                    { 14, 10, 7 },
                    { 15, 11, 7 },
                    { 16, 12, 1 },
                    { 17, 12, 3 },
                    { 18, 13, 1 },
                    { 19, 13, 3 },
                    { 20, 14, 1 },
                    { 21, 14, 9 },
                    { 22, 15, 1 },
                    { 23, 16, 1 },
                    { 24, 17, 9 },
                    { 25, 17, 1 },
                    { 26, 18, 8 },
                    { 27, 19, 8 },
                    { 28, 20, 8 },
                    { 29, 20, 4 },
                    { 30, 21, 13 },
                    { 31, 21, 2 },
                    { 32, 22, 3 },
                    { 33, 23, 4 }
                });

            migrationBuilder.InsertData(
                table: "ProductItems",
                columns: new[] { "id", "color", "image", "product_id", "quantity", "size" },
                values: new object[,]
                {
                    { 1, "Cam", null, 3, 10, "S" },
                    { 2, "Cam", null, 3, 10, "M" },
                    { 3, "Cam", null, 3, 10, "L" },
                    { 4, "Cam", null, 3, 10, "XL" },
                    { 5, "Cam", null, 3, 10, "XXL" },
                    { 6, "Xanh", null, 10, 10, "S" },
                    { 7, "Xanh", null, 10, 10, "M" },
                    { 8, "Xanh", null, 10, 10, "L" },
                    { 9, "Xanh", null, 10, 10, "XL" },
                    { 10, "Xanh", null, 10, 10, "XXL" },
                    { 11, "Hồng", null, 2, 10, "S" },
                    { 12, "Hồng", null, 2, 10, "M" },
                    { 13, "Hồng", null, 2, 10, "L" },
                    { 14, "Hồng", null, 2, 10, "XL" },
                    { 15, "Hồng", null, 2, 10, "XXL" },
                    { 16, "Hồng", null, 11, 10, "S" },
                    { 17, "Hồng", null, 11, 10, "M" },
                    { 18, "Hồng", null, 11, 10, "L" },
                    { 19, "Hồng", null, 11, 10, "XL" },
                    { 20, "Hồng", null, 11, 10, "XXL" },
                    { 21, "Kem", null, 21, 10, "S" },
                    { 22, "Kem", null, 21, 10, "M" },
                    { 23, "Kem", null, 21, 10, "L" },
                    { 24, "Kem", null, 21, 10, "XL" },
                    { 25, "Kem", null, 21, 10, "XXL" },
                    { 26, "Nâu", null, 8, 10, "S" },
                    { 27, "Nâu", null, 8, 10, "M" },
                    { 28, "Nâu", null, 8, 10, "L" },
                    { 29, "Nâu", null, 8, 10, "XL" },
                    { 30, "Nâu", null, 8, 10, "XXL" },
                    { 31, "Nâu", null, 2, 10, "S" },
                    { 32, "Nâu", null, 2, 10, "M" },
                    { 33, "Nâu", null, 2, 10, "L" },
                    { 34, "Nâu", null, 2, 10, "XL" },
                    { 35, "Nâu", null, 2, 10, "XXL" },
                    { 36, "Trắng", null, 5, 10, "S" },
                    { 37, "Trắng", null, 5, 10, "M" },
                    { 38, "Trắng", null, 5, 10, "L" },
                    { 39, "Trắng", null, 5, 10, "XL" },
                    { 40, "Trắng", null, 5, 10, "XXL" },
                    { 41, "Trắng", null, 16, 10, "S" },
                    { 42, "Trắng", null, 16, 10, "M" },
                    { 43, "Trắng", null, 16, 10, "L" },
                    { 44, "Trắng", null, 16, 10, "XL" },
                    { 45, "Trắng", null, 16, 10, "XXL" },
                    { 46, "Trắng", null, 11, 10, "S" },
                    { 47, "Trắng", null, 11, 10, "M" },
                    { 48, "Trắng", null, 11, 10, "L" },
                    { 49, "Trắng", null, 11, 10, "XL" },
                    { 50, "Trắng", null, 11, 10, "XXL" },
                    { 51, "Trắng", null, 10, 10, "S" },
                    { 52, "Trắng", null, 10, 10, "M" },
                    { 53, "Trắng", null, 10, 10, "L" },
                    { 54, "Trắng", null, 10, 10, "XL" },
                    { 55, "Trắng", null, 10, 10, "XXL" },
                    { 56, "Trắng", null, 20, 10, "S" },
                    { 57, "Trắng", null, 20, 10, "M" },
                    { 58, "Trắng", null, 20, 10, "L" },
                    { 59, "Trắng", null, 20, 10, "XL" },
                    { 60, "Trắng", null, 20, 10, "XXL" },
                    { 61, "Trắng", null, 1, 10, "S" },
                    { 62, "Trắng", null, 1, 10, "M" },
                    { 63, "Trắng", null, 1, 10, "L" },
                    { 64, "Trắng", null, 1, 10, "XL" },
                    { 65, "Trắng", null, 1, 10, "XXL" },
                    { 66, "Trắng", null, 3, 10, "S" },
                    { 67, "Trắng", null, 3, 10, "M" },
                    { 68, "Trắng", null, 3, 10, "L" },
                    { 69, "Trắng", null, 3, 10, "XL" },
                    { 70, "Trắng", null, 3, 10, "XXL" },
                    { 71, "Trắng", null, 2, 10, "S" },
                    { 72, "Trắng", null, 2, 10, "M" },
                    { 73, "Trắng", null, 2, 10, "L" },
                    { 74, "Trắng", null, 2, 10, "XL" },
                    { 75, "Trắng", null, 2, 10, "XXL" },
                    { 76, "Trắng", null, 14, 10, "S" },
                    { 77, "Trắng", null, 14, 10, "M" },
                    { 78, "Trắng", null, 14, 10, "L" },
                    { 79, "Trắng", null, 14, 10, "XL" },
                    { 80, "Trắng", null, 14, 10, "XXL" },
                    { 81, "Tím", null, 5, 10, "S" },
                    { 82, "Tím", null, 5, 10, "M" },
                    { 83, "Tím", null, 5, 10, "L" },
                    { 84, "Tím", null, 5, 10, "XL" },
                    { 85, "Tím", null, 5, 10, "XXL" },
                    { 86, "Xanh", null, 11, 10, "S" },
                    { 87, "Xanh", null, 11, 10, "M" },
                    { 88, "Xanh", null, 11, 10, "L" },
                    { 89, "Xanh", null, 11, 10, "XL" },
                    { 90, "Xanh", null, 11, 10, "XXL" },
                    { 91, "Xanh", null, 9, 10, "S" },
                    { 92, "Xanh", null, 9, 10, "M" },
                    { 93, "Xanh", null, 9, 10, "L" },
                    { 94, "Xanh", null, 9, 10, "XL" },
                    { 95, "Xanh", null, 9, 10, "XXL" },
                    { 96, "Xanh", null, 3, 10, "S" },
                    { 97, "Xanh", null, 3, 10, "M" },
                    { 98, "Xanh", null, 3, 10, "L" },
                    { 99, "Xanh", null, 3, 10, "XL" },
                    { 100, "Xanh", null, 3, 10, "XXL" },
                    { 101, "Xanh", null, 18, 10, "S" },
                    { 102, "Xanh", null, 18, 10, "M" },
                    { 103, "Xanh", null, 18, 10, "L" },
                    { 104, "Xanh", null, 18, 10, "XL" },
                    { 105, "Xanh", null, 18, 10, "XXL" },
                    { 106, "Xanh", null, 19, 10, "S" },
                    { 107, "Xanh", null, 19, 10, "M" },
                    { 108, "Xanh", null, 19, 10, "L" },
                    { 109, "Xanh", null, 19, 10, "XL" },
                    { 110, "Xanh", null, 19, 10, "XXL" },
                    { 116, "Xanh", null, 8, 10, "S" },
                    { 117, "Xanh", null, 8, 10, "M" },
                    { 118, "Xanh", null, 8, 10, "L" },
                    { 119, "Xanh", null, 8, 10, "XL" },
                    { 120, "Xanh", null, 8, 10, "XXL" },
                    { 121, "Xanh", null, 6, 10, "S" },
                    { 122, "Xanh", null, 6, 10, "M" },
                    { 123, "Xanh", null, 6, 10, "L" },
                    { 124, "Xanh", null, 6, 10, "XL" },
                    { 125, "Xanh", null, 6, 10, "XXL" },
                    { 126, "Xanh", null, 13, 10, "S" },
                    { 127, "Xanh", null, 13, 10, "M" },
                    { 128, "Xanh", null, 13, 10, "L" },
                    { 129, "Xanh", null, 13, 10, "XL" },
                    { 130, "Xanh", null, 13, 10, "XXL" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "collection_id", "description", "discount_id", "image", "is_active", "name", "price", "slug", "sold", "view" },
                values: new object[,]
                {
                    { 1, null, "Chất liệu Cotton BCI (tổ chức phi lợi nhuận toàn cầu về chương trình bông bền vững)\r\n\r\nGiảm thiểu 50-80% hóa chất so với bông thông thường\r\n\r\nChất lượng được kiểm soát và đảm bảo theo tiêu chuẩn quốc tế\r\n\r\nAn toàn thân thiện với da\r\n\r\nMềm mại, bề mặt vải bông xốp\r\n\r\nThông thoáng, thấm hút, độ bền cao\r\n\r\nÁo có form dáng suông rộng tạo sự thoải mái cho người mặc, thiết kế hình in trước ngực tạo điểm nhấn.\r\n\r\nYODY - Look good. Feel good.", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phong-Nam-Cotton-Dang-Suong-BCI-In-Gau-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phong-Nam-Cotton-Dang-Suong-BCI-In-Gau-2.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phong-Nam-Cotton-Dang-Suong-BCI-In-Gau-3.jpeg" }, true, "Áo Phông Nam Cotton Dáng Suông BCI In Gấu", 190000, "Ao-Phong-Nam-Cotton-Dang-Suong-BCI-In-Gau", 0, 0 },
                    { 2, null, "Áo sơ mi nam dài tay kẻ sọc thiết kế phom dáng thoải mái, trẻ trung\r\n\r\nCổ và nẹp áp được giữ phom cực tốt\r\n\r\nLá cổ có cài cúc, ngực in chữ Connect độc đáo\r\n\r\nHoạ tiết kẻ sọc giúp chiếc áo thêm phần bắt mắt và trẻ trung hơn\r\n\r\nPhù hợp để mặc trong nhiều hoàn cảnh khác nhau: đi làm, đi chơi, gặp đối tác\r\n\r\nCó thể phối cùng quần short, jeans, quần âu, kaki\r\n\r\nYODY - Look good. Feel good.", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-So-Mi-Nam-Tay-Dai-In-Connect-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-So-Mi-Nam-Tay-Dai-In-Connect-2.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-So-Mi-Nam-Tay-Dai-In-Connect-3.webp" }, true, "Áo Sơ Mi Nam Tay Dài In Connect", 350000, "Ao-So-Mi-Nam-Tay-Dai-In-Connect", 0, 0 },
                    { 3, null, "Chất liệu vải Nhung Tăm 100% Cotton\r\n\r\nThoải mái với vải mềm mại và bông, giữ ấm cơ thể tốt\r\n\r\nKhông thể bỏ lỡ một chiếc áo sơ mi dài tay trẻ trung, năng động\r\n\r\nThiết kế cơ bản, cổ áo và nẹp giữ phom trong suốt quá trình xử dụngđ\r\n\r\nĐểm nhấn là ở vị trí ngực áo có thêu chú gấu\r\n\r\nForm dáng suông cơ bản đễ dàng phối đồ\r\n\r\nYODY - Look good. Feel good.", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-So-Mi-Nam-Vai-Nhung-Theu-Gau-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-So-Mi-Nam-Vai-Nhung-Theu-Gau-2.webp" }, true, "Áo Sơ Mi Nam Vải Nhung Thêu Gấu", 250000, "Ao-So-Mi-Nam-Vai-Nhung-Theu-Gau", 0, 0 },
                    { 4, null, "Áo polo nam Sợi Café thấm hút mồ hôi, kiểm soát khử mùi cơ thể cực tốt\r\n\r\nBảo vệ cơ thể nhờ khả năng kháng khuẩn, Chống tia UV\r\n\r\nNhững chiếc áo polo cafe giúp bạn tránh bị ám mùi giữa mùa hè nóng bức khi tham gia các hoạt động ngoài trời với cường độ cao hay đơn giản là đi ăn 1 bữa tiệc nướng\r\n\r\nSản phẩm được tin dùng bởi hàng triệu khách hàng toàn quốc\r\n\r\nYODY - Look good. Feel good", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Polo-Nam-Cafe-Phoi-Nep-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Polo-Nam-Cafe-Phoi-Nep-2.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Polo-Nam-Cafe-Phoi-Nep-3.webp" }, true, "Áo Polo Nam Cafe Phối Nẹp", 300000, "Ao-Polo-Nam-Cafe-Phoi-Nep", 0, 0 },
                    { 5, null, "Áo polo thể thao nam chất liệu mắt chim:  49%Cotton, 47% Polyester, 4% Spandex\r\n\r\nBề mặt vải được thiết kế óng ánh như mắt chim tinh anh mang đến hiệu ứng trẻ trung, mới lạ\r\n\r\nĐộ mềm mại, thấm hút mồ hôi rất tốt, không nhăn nhàu\r\n\r\nCo giãn nhưng vẫn giữ phom, có tính ổn định khi sử dụng\r\n\r\nThiết kế ôm vừa vặn cơ thể rất thoải mái\r\n\r\nHình in 3D trước ngực làm điểm nhấn\r\n\r\nCó thể phối với nhiều trang phục, mặc đi làm, đi chơi, hẹn hò\r\n\r\nYODY - Look good. Feel good.", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Polo-Nam-Mat-Chim-In-Truoc-Nguc-3d-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Polo-Nam-Mat-Chim-In-Truoc-Nguc-3d-2.webp" }, true, "Áo Polo Nam Mắt Chim In Trước Ngực 3d", 350000, "Ao-Polo-Nam-Mat-Chim-In-Truoc-Nguc-3d", 0, 0 },
                    { 6, null, "Quần jeans nam S-Cafe siêu co giãn thoáng mát\r\n\r\nSợi S-cafe: sản xuất từ công nghệ độc quyền có khả năng chống tia UV hiệu quả nhờ khả năng khúc xạ ánh sáng, hạn ché tia UVA và UVB tiếp xúc với cơ thể người mặc\r\n\r\nKiểm soát mùi tốt vì bột café được tích hợp vào sợi café theo công nghệ S.cafe\r\n\r\nCo giãn tốt do có chứa thành phần spandex nên thoải mái khi vận động\r\n\r\nYODY - Look good. Feel good.", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Jean-Nam-Cafe-Than-Thien-Voi-Moi-Truong-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Jean-Nam-Cafe-Than-Thien-Voi-Moi-Truong-2.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Jean-Nam-Cafe-Than-Thien-Voi-Moi-Truong-3.webp" }, true, "Quần Jean Nam Cafe Thân Thiện Với Môi Trường", 600000, "Quan-Jean-Nam-Cafe-Than-Thien-Voi-Moi-Truong", 0, 0 },
                    { 7, null, "Thành phần: 63.5% Cotton USA + 35.5% Polyester + 1% Spandex\r\n\r\nChất liệu cotton USA là một trong những loại nguyên liệu cao cấp được cả thế giới tin dùng\r\n\r\nChất liệu có độ bền cao, mềm mại, thông thoáng và thấm hút tốt.\r\n\r\nCo giãn nhẹ do có chứa thành phần spandex.\r\n\r\nYODY - Look good. Feel good.", null, new string[0], true, "Quần Jeans Nam Cotton Chỉ Phối Màu", 580000, "Quan-Jeans-Nam-Cotton-Chi-Phoi-Mau", 0, 0 },
                    { 8, null, "Chất liệu Kaki co giãn thoải mái khi mặc\r\n\r\nThiết kế cơ bản túi chéo canh sườn và túi hậu có cái cúc, cạp quần to chắc chắn có đỉa để đeo thắt lưng\r\n\r\nQuần kaki nam slim phù hợp cho nam giới và có thể sử dụng trong nhiều hoàn cảnh khác nhau\r\n\r\nYODY - Look good. Feel good.", null, new string[0], true, "Quần Kaki Nam Slim", 350000, "Quan-Kaki-Nam-Slim", 0, 0 },
                    { 9, null, "Quần kaki nam dáng regular thoải mái, dễ mặc\r\n\r\nChất liệu kaki dày dặn, bền chắc\r\n\r\nThiết kế basic, phù hợp với nhiều dáng người châu Á\r\n\r\nThích hợp mặc đi làm, đi chơi, đi học\r\n\r\nPhối đồ đa dạng cùng sơ mi, áo thun, áo polo, áo khoác…\r\n\r\nYODY - Look good. Feel good.", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Kaki-Nam-Regular-Theu-Canh-Tui-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Kaki-Nam-Regular-Theu-Canh-Tui-2.webp" }, true, "Quần Kaki Nam Regular Thêu Cạnh Túi", 500000, "Quan-Kaki-Nam-Regular-Theu-Canh-Tui", 0, 0 },
                    { 10, null, "Áo thun thể thao nam chất liệu bền bỉ\r\n\r\nMát mịn, mềm mại, tạo cảm giác thoải mái khi mặc\r\n\r\nCo giãn đàn hồi tuyệt vời trong quá trình tập luyện\r\n\r\nThấm hút tốt, khô nhanh, thông thoáng nhờ kiểu dệt\r\n\r\nSiêu nhẹ đem lại trải nghiệm tuyệt vời cho người sử dụng\r\n\r\nDáng suông cùng thiết kế cơ bản hình in Limitless\r\n\r\nYODY - Look good. Feel good.", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Thun-The-Thao-Nam-Sieu-Nhe-In-Limitless-1.png", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Thun-The-Thao-Nam-Sieu-Nhe-In-Limitless-2.webp" }, true, "Áo Thun Thể Thao Nam Siệu Nhẹ In Limitless", 300000, "Ao-Thun-The-Thao-Nam-Sieu-Nhe-In-Limitless", 0, 0 },
                    { 11, null, "Áo thun thể thao nam chất liệu Polyester siêu nhẹ đem lại trải nghiệm tuyệt vời\r\n\r\nVải mềm mại với công nghệ dệt Jacquard hiện đại tạo họa tiết lỗ độc đáo\r\n\r\nKiểu dệt giúp áo thấm hút tốt, khô nhanh, thông thoáng mang đến cảm thoải mái cho làn da\r\n\r\nIn chữ Run độc đáo làm điểm nhấn\r\n\r\nKiểu dáng basic dễ mặc, phối được với nhiều trang phục sử dụng hằng ngày\r\n\r\nYODY - Look good. Feel good.", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/T-Shirt-The-Thao-Nam-Sieu-Nhe-In-Run-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/T-Shirt-The-Thao-Nam-Sieu-Nhe-In-Run-2.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/T-Shirt-The-Thao-Nam-Sieu-Nhe-In-Run-3.webp" }, true, "T-Shirt Thể Thao Nam Siêu Nhẹ In Run", 300000, "T-Shirt-The-Thao-Nam-Sieu-Nhe-In-Run", 0, 0 },
                    { 12, null, "Vest nam lịch lãm, nâng tầm đẳng cấp cho phái mạnh\r\n\r\nKiểu dáng slim fit với ngực, eo và tay áo vừa vặn tôn dáng\r\n\r\nVe áo hẹp với chi tiết thùa khuyết, có thể cài chặt bằng nút phía trước\r\n\r\nThân áo có túi 2 bên cân xứng cùng túi bên trong giúp để những vật dụng quan trọng như ví, thẻ\r\n\r\nHàng cúc trên cổ tay áo có bọ nổi tinh tế\r\n\r\nYODY - Look good. Feel good", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Vest-Nam-1-Tui-Coi-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Vest-Nam-1-Tui-Coi-2.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Vest-Nam-1-Tui-Coi-3.webp" }, true, "Áo Vest Nam 1 Túi Cơi", 800000, "Ao-Vest-Nam-1-Tui-Coi", 0, 0 },
                    { 13, null, "Chất liệu vải Nano\r\n\r\nVe áo hẹp với chi tiết thùa khuyết. Ve áo được cài chặt bằng hai nút phía trước\r\n\r\nThân trước có 2 bên túi cân xứng cùng túi trong giúp để những vật dụng quan trọng như ví, thẻ\r\n\r\nHàng cúc trên cổ tay áo có bọ nổi\r\n\r\nKiểu dáng slim fit, vừa vặn với ngực và eo, và tay áo\r\n\r\nYODY - Look good. Feel good", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Vest-Nam-Nano-Cong-So-Tre-Trung-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Vest-Nam-Nano-Cong-So-Tre-Trung-2.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Vest-Nam-Nano-Cong-So-Tre-Trung-3.webp" }, true, "Áo Vest Nam Nano Công Sở Trẻ Trung", 800000, "Ao-Vest-Nam-Nano-Cong-So-Tre-Trung", 0, 0 },
                    { 14, null, "Dòng Áo Phao 3S mùa đông năm 2022\r\n\r\nÁo có cấu trúc 3 lớp chắc chắn: Lớp ngoài và lớp lót được làm từ 100% Nylon, Lớp giữa bông nhẹ 100% polyester\r\n\r\nMàu sắc sản phẩm đa dạng, thiết kế form dáng trẻ trung\r\n\r\nCó thiết kế túi đựng nhỏ gọn, dễ dàng mang theo sản phẩm\r\n\r\nSiêu nhẹ, có tác dụng giữ ấm cho cơ thể\r\n\r\nÁo có thể tránh mưa nhẹ, chống tĩnh điện\r\n\r\nYODY - Look good. Feel good", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phao-Nam-Co-Mu-Sieu-Nhe-Sieu-Am-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phao-Nam-Co-Mu-Sieu-Nhe-Sieu-Am-2.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phao-Nam-Co-Mu-Sieu-Nhe-Sieu-Am-3.webp" }, true, "Áo Phao Nam Có Mũ Siêu Nhẹ Siêu Ấm", 600000, "Ao-Phao-Nam-Co-Mu-Sieu-Nhe-Sieu-Am", 0, 0 },
                    { 15, null, "Áo khoác bomber nam vải gió giúp giữ ấm cơ thể tốt\r\n\r\nKiểu dáng thời trang cùng màu sắc trẻ trung, năng động, dễ dàng phối với nhiều trang phục khác nhau\r\n\r\nThiết kế bo len cổ, tay và gấu áo tạo độ ôm vừa phải mang đến cảm giác thoải mái khi mặc\r\n\r\nTay áo có túi khóa tạo sự khỏe khoắn và để đồ tiện lợi, chắc chắn\r\n\r\nĐường may tỉ mỉ, có độ bền cao khi sử dụng\r\n\r\nYODY - Look good. Feel good.", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Khoac-Nam-Bomber-Bo-Nguc-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Khoac-Nam-Bomber-Bo-Nguc-2.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Khoac-Nam-Bomber-Bo-Nguc-3.webp" }, true, "Áo Khoác Nam Bomber Bổ Ngực", 600000, "Ao-Khoac-Nam-Bomber-Bo-Nguc", 0, 0 },
                    { 16, null, "Chất liệu thành phần: 88% nylon, 12% spandex    \r\n\r\nÁo khoác nam cản gió, cản bụi, giữ ấm\r\n\r\nThoải mái dễ dàng vận động với chất liệu co giãn 4 chiều\r\n\r\nKhóa kéo bền bỉ, kéo dễ dàng\r\n\r\nThiết kế trẻ trung, hiện đại, giữ ấm tốt đồng thời phù hợp phối đồ đa dạng\r\n\r\nYODY - Look good. Feel good.", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Khoac-Nam-Chun-Bo-Gau-Can-Gio-Can-Bui-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Khoac-Nam-Chun-Bo-Gau-Can-Gio-Can-Bui-2.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Khoac-Nam-Chun-Bo-Gau-Can-Gio-Can-Bui-3.webp" }, true, "Áo Khoác Nam Chun Bo Gấu Cản Gió Cản Bụi", 700000, "Ao-Khoac-Nam-Chun-Bo-Gau-Can-Gio-Can-Bui", 0, 0 },
                    { 17, null, "Màu sắc sản phẩm đa dạng, thiết kế form dáng trẻ trung\r\n\r\nCó thiết kế túi đựng nhỏ gọn, dễ dàng mang theo sản phẩm\r\n\r\nSiêu nhẹ, có tác dụng giữ ấm cho cơ thể\r\n\r\nChống thấm nước, tránh mưa nhẹ, chống tĩnh điện\r\n\r\nYODY - Look good. Feel good", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phao-Nam-Sieu-Nhe-Co-Mu-Sieu-Am-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phao-Nam-Sieu-Nhe-Co-Mu-Sieu-Am-2.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phao-Nam-Sieu-Nhe-Co-Mu-Sieu-Am-3.webp" }, true, "Áo Phao Nam Siêu Nhẹ Có Mũ Siêu Ấm", 600000, "Ao-Phao-Nam-Sieu-Nhe-Co-Mu-Sieu-Am", 0, 0 },
                    { 18, null, "Quần short nam thể thao YODY\r\n\r\nChất liệu mềm mại, nhẹ nhàng phù hợp vận động\r\n\r\nThiết kế thể thao, khỏe khoắn. Cạp chun cả vòng bản to vô cùng khỏe khoắn\r\n\r\nDây rút chất lượng bền đẹp\r\n\r\nTúi cạnh sườn có khóa kéo để đồ tiện lợi \r\n\r\nYODY - Look good. Feel good.", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-Nam-Ong-Rong-Thoang-Mat-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-Nam-Ong-Rong-Thoang-Mat-2.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-Nam-Ong-Rong-Thoang-Mat-3.webp" }, true, "Quần Short Nam Ống Rộng Thoáng Mát", 200000, "Quan-Short-Nam-Ong-Rong-Thoang-Mat", 0, 0 },
                    { 19, null, "Quần short gió nam thể thao ngang gối\r\n\r\nThiết kế cơ bản có dây rút, dễ dàng điều chỉnh theo số đo cơ thể\r\n\r\nBản cạp chun to chắc chắn có phối chun thoải mái, không hằn bụng\r\n\r\nMiệng túi có khóa vô cùng tiện lợi cho việc đựng đồ\r\n\r\nSản phẩm phù hợp cho nhiều độ tuồi và sử dụng được cho nhiều hoàn cảnh khác nhau\r\n\r\nYODY - Look good. Feel good.", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-The-Thao-Nam-Phoi-Cap-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-The-Thao-Nam-Phoi-Cap-2.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-The-Thao-Nam-Phoi-Cap-3.webp" }, true, "Quần Short Thể Thao Nam Phối Cạp", 400000, "Quan-Short-The-Thao-Nam-Phoi-Cap", 0, 0 },
                    { 20, null, "Chất liệu Kaki mềm nhẹ, thoải mái\r\n\r\nQuần short nam thiết kế cơ bản dài ngang gối\r\n\r\nCạp quần to bản có đỉa tiện lợi\r\n\r\nTúi cúc phía sau có thể đựng đồ nhỏ gọn như ví, chìa khóa\r\n\r\nPhom dáng trẻ trung, lịch lãm tạo sự chỉn chu, thích hợp mặc ở nhà hay ra ngoài cafe, hẹn hò\r\n\r\nSản phẩm basic dành cho mọi chàng trai\r\n\r\nYODY - Look good. Feel good.", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-Nam-Kaki-Ong-DJung-Lich-Lam-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-Nam-Kaki-Ong-DJung-Lich-Lam-2.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-Nam-Kaki-Ong-DJung-Lich-Lam-3.webp" }, true, "Quần Short Nam Kaki Ống Đứng Lịch Lãm", 350000, "Quan-Short-Nam-Kaki-Ong-DJung-Lich-Lam", 0, 0 },
                    { 21, null, "Với sự phát triển của thời trang, áo len đang ngày một được cải tiến và đa dạng về thiết kế hơn để trở thành thường phục hàng ngày. Ngoài những kiểu dáng truyền thống, các nhãn hàng thời trang đã không ngừng tạo ra nhiều kiểu dáng độc lạ, mới mẽ hơn để các tín đồ áo len thỏa sức lựa chọn cho mình một item phù hợp nhất.\r\n\r\nÁo Dệt Kim Tay Dài Cổ Tròn Phối Sọc. Regular - 10F22KNI010 có form áo Regular với đặc trưng là phần áo suông thẳng không quá rộng giúp phái mạnh có thể che được những điểm mà bản thân chưa tự tin nhưng không mang lại cảm giác lùng bùng. Hơn nữa, với điểm nhấn là màu sắc được phối một cách tinh tế, hài hoà đã giúp mẫu áo với thiết kế cổ tròn, tay dài basic này trở nên vừa dễ phối đồ vừa không mang cảm giác đơn điệu. Đặc biệt, khả năng giữ ấm cũng như nhanh khô của chất liệu acrylic sẽ là lựa chọn tuyệt vời với khí hậu lạnh ẩm trong mùa thu đông.", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Len-Nam-Tay-Dai-Co-V-Ke-Soc-Form-Regular-1.jpeg", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Len-Nam-Tay-Dai-Co-V-Ke-Soc-Form-Regular-2.jpeg", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Len-Nam-Tay-Dai-Co-V-Ke-Soc-Form-Regular-3.jpeg", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Len-Nam-Tay-Dai-Co-V-Ke-Soc-Form-Regular-4.jpeg" }, true, "Áo Len Nam Tay Dài Cổ V Kẻ Sọc Form Regular", 540000, "Ao-Len-Nam-Tay-Dai-Co-V-Ke-Soc-Form-Regular", 0, 0 },
                    { 22, null, "Với sự phát triển của thời trang, áo len đang ngày một được cải tiến và đa dạng về thiết kế hơn để trở thành thường phục hàng ngày. Ngoài những kiểu dáng truyền thống, các nhãn hàng thời trang đã không ngừng tạo ra nhiều kiểu dáng độc lạ, mới mẽ hơn để các tín đồ áo len thỏa sức lựa chọn cho mình một item phù hợp nhất.\r\n\r\nÁo Dệt Kim Tay Dài Cổ Tròn Phối Sọc. Regular - 10F22KNI010 có form áo Regular với đặc trưng là phần áo suông thẳng không quá rộng giúp phái mạnh có thể che được những điểm mà bản thân chưa tự tin nhưng không mang lại cảm giác lùng bùng. Hơn nữa, với điểm nhấn là màu sắc được phối một cách tinh tế, hài hoà đã giúp mẫu áo với thiết kế cổ tròn, tay dài basic này trở nên vừa dễ phối đồ vừa không mang cảm giác đơn điệu. Đặc biệt, khả năng giữ ấm cũng như nhanh khô của chất liệu acrylic sẽ là lựa chọn tuyệt vời với khí hậu lạnh ẩm trong mùa thu đông.", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Len-Det-Kim-Tay-Dai-Co-Tron-Phoi-Soc-Hien-DJai-1.jpeg", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Len-Det-Kim-Tay-Dai-Co-Tron-Phoi-Soc-Hien-DJai-2.jpeg", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Len-Det-Kim-Tay-Dai-Co-Tron-Phoi-Soc-Hien-DJai-3.jpeg" }, true, "Áo Len Dệt Kim Tay Dài Cổ Tròn Phối Sọc Hiện Đại", 679000, "Ao-Len-Det-Kim-Tay-Dai-Co-Tron-Phoi-Soc-Hien-DJai", 0, 0 },
                    { 23, null, "Áo thun nam 100% Cotton thân thiện - lành tính\r\n\r\nThành phần:  100% Cotton\r\n\r\nVải Cotton Compact được dệt từ sợi bông USA sạch, góp phần bảo vệ môi trường sống\r\n\r\nÁo có khả năng co giãn đàn hồi, thấm hút mồ hôi tốt, thoáng mát, rất thích hợp với thời tiết nóng ẩm việt Nam\r\n\r\nThiết kế cá tính - trẻ trung - hiện đại, thoải mái cho phối đồ của bạn sáng tạo và phá cách\r\n\r\nKhuyến cáo Giặt sản phẩm trước khi mặc\r\n\r\nYODY - Look good. Feel good.", null, new[] { "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/T-Shirt-Nam-Dang-Rong-In-Chu-Nguc-1.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/T-Shirt-Nam-Dang-Rong-In-Chu-Nguc-2.webp", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/T-Shirt-Nam-Dang-Rong-In-Chu-Nguc-3.webp" }, true, "T-Shirt Nam Dáng Rộng In Chữ Ngực", 244000, "T-Shirt-Nam-Dang-Rong-In-Chu-Nguc", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "id", "discount_id", "name" },
                values: new object[,]
                {
                    { 1, null, "Áo khoác" },
                    { 2, null, "Áo len" },
                    { 3, null, "Áo vest" },
                    { 4, null, "Quần kaki" },
                    { 5, null, "Quần jean" },
                    { 6, null, "Áo polo" },
                    { 7, null, "Áo thun ngắn tay" },
                    { 8, null, "Quần đùi" },
                    { 9, null, "Áo phao" },
                    { 10, null, "Áo sơ mi" },
                    { 11, null, "Vải nhung" },
                    { 12, null, "Vải cotton" },
                    { 13, null, "Áo tay dài" },
                    { 14, null, "Quần dài" }
                });

            migrationBuilder.InsertData(
                table: "Vouchers",
                columns: new[] { "code", "description", "discount", "due", "is_active", "name" },
                values: new object[,]
                {
                    { "ABC123", "", 5.0, new DateOnly(2023, 12, 31), false, "Khuyến mãi 2" },
                    { "ABCDEF", "", 20.0, new DateOnly(2023, 12, 31), true, "Khuyến mãi 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "HasTags",
                keyColumn: "id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Vouchers",
                keyColumn: "code",
                keyValue: "ABC123");

            migrationBuilder.DeleteData(
                table: "Vouchers",
                keyColumn: "code",
                keyValue: "ABCDEF");
        }
    }
}

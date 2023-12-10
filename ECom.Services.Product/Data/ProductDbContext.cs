using ECom.Services.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ECom.Services.Products.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<HaveTag> HasTags { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }


        //private string connectionString { get; set; }

        public ProductDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var builder =
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true)
                    .AddEnvironmentVariables();

            IConfiguration config = builder.Build();

            string connect = config.GetConnectionString("DefaultConnection");
            options.UseNpgsql(connect);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discount>().HasData(
                new Discount { Id = 1, Name = "Hàng mới về", DiscountAmount = 5 },
                new Discount { Id = 2, Name = "Hàng tồn kho", DiscountAmount = 15 },
                new Discount { Id = 3, Name = "Hàng vải mới", DiscountAmount = 20 }
                );
            modelBuilder.Entity<Collection>().HasData(
                new Collection { Id = 1, Name = "Thu - Đông", DiscountId = null },
                new Collection { Id = 2, Name = "Xuân - Hè", DiscountId = null },
                new Collection { Id = 3, Name = "Thể thao", DiscountId = null },
                new Collection { Id = 4, Name = "Bơi lội", DiscountId = null }
                );
            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "Áo khoác", DiscountId = null },
                new Tag { Id = 2, Name = "Áo len", DiscountId = null },
                new Tag { Id = 3, Name = "Áo vest", DiscountId = null },
                new Tag { Id = 4, Name = "Quần kaki", DiscountId = null },
                new Tag { Id = 5, Name = "Quần jean", DiscountId = null },
                new Tag { Id = 6, Name = "Áo polo", DiscountId = null },
                new Tag { Id = 7, Name = "Áo thun ngắn tay", DiscountId = null },
                new Tag { Id = 8, Name = "Quần đùi", DiscountId = null },
                new Tag { Id = 9, Name = "Áo phao", DiscountId = null },
                new Tag { Id = 10, Name = "Áo sơ mi", DiscountId = null },
                new Tag { Id = 11, Name = "Vải nhung", DiscountId = null },
                new Tag { Id = 12, Name = "Vải cotton", DiscountId = null },
                new Tag { Id = 13, Name = "Áo tay dài", DiscountId = null },
                new Tag { Id = 14, Name = "Quần dài", DiscountId = null }
                );
            modelBuilder.Entity<Models.Product>().HasData(
                new Models.Product
                {
                    Id = 1,
                    Name = "Áo Phông Nam Cotton Dáng Suông BCI In Gấu",
                    Price = 190000,
                    Description = "Chất liệu Cotton BCI (tổ chức phi lợi nhuận toàn cầu về chương trình bông bền vững)\r\n\r\nGiảm thiểu 50-80% hóa chất so với bông thông thường\r\n\r\nChất lượng được kiểm soát và đảm bảo theo tiêu chuẩn quốc tế\r\n\r\nAn toàn thân thiện với da\r\n\r\nMềm mại, bề mặt vải bông xốp\r\n\r\nThông thoáng, thấm hút, độ bền cao\r\n\r\nÁo có form dáng suông rộng tạo sự thoải mái cho người mặc, thiết kế hình in trước ngực tạo điểm nhấn.\r\n\r\nYODY - Look good. Feel good.",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phong-Nam-Cotton-Dang-Suong-BCI-In-Gau-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phong-Nam-Cotton-Dang-Suong-BCI-In-Gau-2.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phong-Nam-Cotton-Dang-Suong-BCI-In-Gau-3.jpeg"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Ao-Phong-Nam-Cotton-Dang-Suong-BCI-In-Gau"
                },
                new Models.Product
                {
                    Id = 2,
                    Name = "Áo Sơ Mi Nam Tay Dài In Connect",
                    Price = 350000,
                    Description = "Áo sơ mi nam dài tay kẻ sọc thiết kế phom dáng thoải mái, trẻ trung\r\n\r\nCổ và nẹp áp được giữ phom cực tốt\r\n\r\nLá cổ có cài cúc, ngực in chữ Connect độc đáo\r\n\r\nHoạ tiết kẻ sọc giúp chiếc áo thêm phần bắt mắt và trẻ trung hơn\r\n\r\nPhù hợp để mặc trong nhiều hoàn cảnh khác nhau: đi làm, đi chơi, gặp đối tác\r\n\r\nCó thể phối cùng quần short, jeans, quần âu, kaki\r\n\r\nYODY - Look good. Feel good.",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-So-Mi-Nam-Tay-Dai-In-Connect-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-So-Mi-Nam-Tay-Dai-In-Connect-2.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-So-Mi-Nam-Tay-Dai-In-Connect-3.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Ao-So-Mi-Nam-Tay-Dai-In-Connect"
                },
                new Models.Product
                {
                    Id = 3,
                    Name = "Áo Sơ Mi Nam Vải Nhung Thêu Gấu",
                    Price = 250000,
                    Description = "Chất liệu vải Nhung Tăm 100% Cotton\r\n\r\nThoải mái với vải mềm mại và bông, giữ ấm cơ thể tốt\r\n\r\nKhông thể bỏ lỡ một chiếc áo sơ mi dài tay trẻ trung, năng động\r\n\r\nThiết kế cơ bản, cổ áo và nẹp giữ phom trong suốt quá trình xử dụngđ\r\n\r\nĐểm nhấn là ở vị trí ngực áo có thêu chú gấu\r\n\r\nForm dáng suông cơ bản đễ dàng phối đồ\r\n\r\nYODY - Look good. Feel good.",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-So-Mi-Nam-Vai-Nhung-Theu-Gau-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-So-Mi-Nam-Vai-Nhung-Theu-Gau-2.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Ao-So-Mi-Nam-Vai-Nhung-Theu-Gau"
                },
                new Models.Product
                {
                    Id = 4,
                    Name = "Áo Polo Nam Cafe Phối Nẹp",
                    Price = 300000,
                    Description = "Áo polo nam Sợi Café thấm hút mồ hôi, kiểm soát khử mùi cơ thể cực tốt\r\n\r\nBảo vệ cơ thể nhờ khả năng kháng khuẩn, Chống tia UV\r\n\r\nNhững chiếc áo polo cafe giúp bạn tránh bị ám mùi giữa mùa hè nóng bức khi tham gia các hoạt động ngoài trời với cường độ cao hay đơn giản là đi ăn 1 bữa tiệc nướng\r\n\r\nSản phẩm được tin dùng bởi hàng triệu khách hàng toàn quốc\r\n\r\nYODY - Look good. Feel good",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Polo-Nam-Cafe-Phoi-Nep-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Polo-Nam-Cafe-Phoi-Nep-2.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Polo-Nam-Cafe-Phoi-Nep-3.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Ao-Polo-Nam-Cafe-Phoi-Nep"
                },
                new Models.Product
                {
                    Id = 5,
                    Name = "Áo Polo Nam Mắt Chim In Trước Ngực 3d",
                    Price = 350000,
                    Description = "Áo polo thể thao nam chất liệu mắt chim:  49%Cotton, 47% Polyester, 4% Spandex\r\n\r\nBề mặt vải được thiết kế óng ánh như mắt chim tinh anh mang đến hiệu ứng trẻ trung, mới lạ\r\n\r\nĐộ mềm mại, thấm hút mồ hôi rất tốt, không nhăn nhàu\r\n\r\nCo giãn nhưng vẫn giữ phom, có tính ổn định khi sử dụng\r\n\r\nThiết kế ôm vừa vặn cơ thể rất thoải mái\r\n\r\nHình in 3D trước ngực làm điểm nhấn\r\n\r\nCó thể phối với nhiều trang phục, mặc đi làm, đi chơi, hẹn hò\r\n\r\nYODY - Look good. Feel good.",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Polo-Nam-Mat-Chim-In-Truoc-Nguc-3d-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Polo-Nam-Mat-Chim-In-Truoc-Nguc-3d-2.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Ao-Polo-Nam-Mat-Chim-In-Truoc-Nguc-3d"
                },
                new Models.Product
                {
                    Id = 6,
                    Name = "Quần Jean Nam Cafe Thân Thiện Với Môi Trường",
                    Price = 600000,
                    Description = "Quần jeans nam S-Cafe siêu co giãn thoáng mát\r\n\r\nSợi S-cafe: sản xuất từ công nghệ độc quyền có khả năng chống tia UV hiệu quả nhờ khả năng khúc xạ ánh sáng, hạn ché tia UVA và UVB tiếp xúc với cơ thể người mặc\r\n\r\nKiểm soát mùi tốt vì bột café được tích hợp vào sợi café theo công nghệ S.cafe\r\n\r\nCo giãn tốt do có chứa thành phần spandex nên thoải mái khi vận động\r\n\r\nYODY - Look good. Feel good.",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Jean-Nam-Cafe-Than-Thien-Voi-Moi-Truong-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Jean-Nam-Cafe-Than-Thien-Voi-Moi-Truong-2.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Jean-Nam-Cafe-Than-Thien-Voi-Moi-Truong-3.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Quan-Jean-Nam-Cafe-Than-Thien-Voi-Moi-Truong"
                },
                new Models.Product
                {
                    Id = 7,
                    Name = "Quần Jeans Nam Cotton Chỉ Phối Màu",
                    Price = 580000,
                    Description = "Thành phần: 63.5% Cotton USA + 35.5% Polyester + 1% Spandex\r\n\r\nChất liệu cotton USA là một trong những loại nguyên liệu cao cấp được cả thế giới tin dùng\r\n\r\nChất liệu có độ bền cao, mềm mại, thông thoáng và thấm hút tốt.\r\n\r\nCo giãn nhẹ do có chứa thành phần spandex.\r\n\r\nYODY - Look good. Feel good.",
                    Image = new string[] { },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Quan-Jeans-Nam-Cotton-Chi-Phoi-Mau"
                },
                new Models.Product
                {
                    Id = 8,
                    Name = "Quần Kaki Nam Slim",
                    Price = 350000,
                    Description = "Chất liệu Kaki co giãn thoải mái khi mặc\r\n\r\nThiết kế cơ bản túi chéo canh sườn và túi hậu có cái cúc, cạp quần to chắc chắn có đỉa để đeo thắt lưng\r\n\r\nQuần kaki nam slim phù hợp cho nam giới và có thể sử dụng trong nhiều hoàn cảnh khác nhau\r\n\r\nYODY - Look good. Feel good.",
                    Image = new string[] { },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Quan-Kaki-Nam-Slim"
                },
                new Models.Product
                {
                    Id = 9,
                    Name = "Quần Kaki Nam Regular Thêu Cạnh Túi",
                    Price = 500000,
                    Description = "Quần kaki nam dáng regular thoải mái, dễ mặc\r\n\r\nChất liệu kaki dày dặn, bền chắc\r\n\r\nThiết kế basic, phù hợp với nhiều dáng người châu Á\r\n\r\nThích hợp mặc đi làm, đi chơi, đi học\r\n\r\nPhối đồ đa dạng cùng sơ mi, áo thun, áo polo, áo khoác…\r\n\r\nYODY - Look good. Feel good.",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Kaki-Nam-Regular-Theu-Canh-Tui-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Kaki-Nam-Regular-Theu-Canh-Tui-2.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Quan-Kaki-Nam-Regular-Theu-Canh-Tui"
                },
                new Models.Product
                {
                    Id = 10,
                    Name = "Áo Thun Thể Thao Nam Siệu Nhẹ In Limitless",
                    Price = 300000,
                    Description = "Áo thun thể thao nam chất liệu bền bỉ\r\n\r\nMát mịn, mềm mại, tạo cảm giác thoải mái khi mặc\r\n\r\nCo giãn đàn hồi tuyệt vời trong quá trình tập luyện\r\n\r\nThấm hút tốt, khô nhanh, thông thoáng nhờ kiểu dệt\r\n\r\nSiêu nhẹ đem lại trải nghiệm tuyệt vời cho người sử dụng\r\n\r\nDáng suông cùng thiết kế cơ bản hình in Limitless\r\n\r\nYODY - Look good. Feel good.",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Thun-The-Thao-Nam-Sieu-Nhe-In-Limitless-1.png",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Thun-The-Thao-Nam-Sieu-Nhe-In-Limitless-2.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Ao-Thun-The-Thao-Nam-Sieu-Nhe-In-Limitless"
                },
                new Models.Product
                {
                    Id = 11,
                    Name = "T-Shirt Thể Thao Nam Siêu Nhẹ In Run",
                    Price = 300000,
                    Description = "Áo thun thể thao nam chất liệu Polyester siêu nhẹ đem lại trải nghiệm tuyệt vời\r\n\r\nVải mềm mại với công nghệ dệt Jacquard hiện đại tạo họa tiết lỗ độc đáo\r\n\r\nKiểu dệt giúp áo thấm hút tốt, khô nhanh, thông thoáng mang đến cảm thoải mái cho làn da\r\n\r\nIn chữ Run độc đáo làm điểm nhấn\r\n\r\nKiểu dáng basic dễ mặc, phối được với nhiều trang phục sử dụng hằng ngày\r\n\r\nYODY - Look good. Feel good.",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/T-Shirt-The-Thao-Nam-Sieu-Nhe-In-Run-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/T-Shirt-The-Thao-Nam-Sieu-Nhe-In-Run-2.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/T-Shirt-The-Thao-Nam-Sieu-Nhe-In-Run-3.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "T-Shirt-The-Thao-Nam-Sieu-Nhe-In-Run"
                },
                new Models.Product
                {
                    Id = 12,
                    Name = "Áo Vest Nam 1 Túi Cơi",
                    Price = 800000,
                    Description = "Vest nam lịch lãm, nâng tầm đẳng cấp cho phái mạnh\r\n\r\nKiểu dáng slim fit với ngực, eo và tay áo vừa vặn tôn dáng\r\n\r\nVe áo hẹp với chi tiết thùa khuyết, có thể cài chặt bằng nút phía trước\r\n\r\nThân áo có túi 2 bên cân xứng cùng túi bên trong giúp để những vật dụng quan trọng như ví, thẻ\r\n\r\nHàng cúc trên cổ tay áo có bọ nổi tinh tế\r\n\r\nYODY - Look good. Feel good",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Vest-Nam-1-Tui-Coi-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Vest-Nam-1-Tui-Coi-2.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Vest-Nam-1-Tui-Coi-3.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Ao-Vest-Nam-1-Tui-Coi"
                },
                new Models.Product
                {
                    Id = 13,
                    Name = "Áo Vest Nam Nano Công Sở Trẻ Trung",
                    Price = 800000,
                    Description = "Chất liệu vải Nano\r\n\r\nVe áo hẹp với chi tiết thùa khuyết. Ve áo được cài chặt bằng hai nút phía trước\r\n\r\nThân trước có 2 bên túi cân xứng cùng túi trong giúp để những vật dụng quan trọng như ví, thẻ\r\n\r\nHàng cúc trên cổ tay áo có bọ nổi\r\n\r\nKiểu dáng slim fit, vừa vặn với ngực và eo, và tay áo\r\n\r\nYODY - Look good. Feel good",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Vest-Nam-Nano-Cong-So-Tre-Trung-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Vest-Nam-Nano-Cong-So-Tre-Trung-2.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Vest-Nam-Nano-Cong-So-Tre-Trung-3.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Ao-Vest-Nam-Nano-Cong-So-Tre-Trung"
                },
                new Models.Product
                {
                    Id = 14,
                    Name = "Áo Phao Nam Có Mũ Siêu Nhẹ Siêu Ấm",
                    Price = 600000,
                    Description = "Dòng Áo Phao 3S mùa đông năm 2022\r\n\r\nÁo có cấu trúc 3 lớp chắc chắn: Lớp ngoài và lớp lót được làm từ 100% Nylon, Lớp giữa bông nhẹ 100% polyester\r\n\r\nMàu sắc sản phẩm đa dạng, thiết kế form dáng trẻ trung\r\n\r\nCó thiết kế túi đựng nhỏ gọn, dễ dàng mang theo sản phẩm\r\n\r\nSiêu nhẹ, có tác dụng giữ ấm cho cơ thể\r\n\r\nÁo có thể tránh mưa nhẹ, chống tĩnh điện\r\n\r\nYODY - Look good. Feel good",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phao-Nam-Co-Mu-Sieu-Nhe-Sieu-Am-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phao-Nam-Co-Mu-Sieu-Nhe-Sieu-Am-2.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phao-Nam-Co-Mu-Sieu-Nhe-Sieu-Am-3.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Ao-Phao-Nam-Co-Mu-Sieu-Nhe-Sieu-Am"
                },
                new Models.Product
                {
                    Id = 15,
                    Name = "Áo Khoác Nam Bomber Bổ Ngực",
                    Price = 600000,
                    Description = "Áo khoác bomber nam vải gió giúp giữ ấm cơ thể tốt\r\n\r\nKiểu dáng thời trang cùng màu sắc trẻ trung, năng động, dễ dàng phối với nhiều trang phục khác nhau\r\n\r\nThiết kế bo len cổ, tay và gấu áo tạo độ ôm vừa phải mang đến cảm giác thoải mái khi mặc\r\n\r\nTay áo có túi khóa tạo sự khỏe khoắn và để đồ tiện lợi, chắc chắn\r\n\r\nĐường may tỉ mỉ, có độ bền cao khi sử dụng\r\n\r\nYODY - Look good. Feel good.",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Khoac-Nam-Bomber-Bo-Nguc-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Khoac-Nam-Bomber-Bo-Nguc-2.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Khoac-Nam-Bomber-Bo-Nguc-3.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Ao-Khoac-Nam-Bomber-Bo-Nguc"
                },
                new Models.Product
                {
                    Id = 16,
                    Name = "Áo Khoác Nam Chun Bo Gấu Cản Gió Cản Bụi",
                    Price = 700000,
                    Description = "Chất liệu thành phần: 88% nylon, 12% spandex    \r\n\r\nÁo khoác nam cản gió, cản bụi, giữ ấm\r\n\r\nThoải mái dễ dàng vận động với chất liệu co giãn 4 chiều\r\n\r\nKhóa kéo bền bỉ, kéo dễ dàng\r\n\r\nThiết kế trẻ trung, hiện đại, giữ ấm tốt đồng thời phù hợp phối đồ đa dạng\r\n\r\nYODY - Look good. Feel good.",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Khoac-Nam-Chun-Bo-Gau-Can-Gio-Can-Bui-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Khoac-Nam-Chun-Bo-Gau-Can-Gio-Can-Bui-2.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Khoac-Nam-Chun-Bo-Gau-Can-Gio-Can-Bui-3.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Ao-Khoac-Nam-Chun-Bo-Gau-Can-Gio-Can-Bui"
                },
                new Models.Product
                {
                    Id = 17,
                    Name = "Áo Phao Nam Siêu Nhẹ Có Mũ Siêu Ấm",
                    Price = 600000,
                    Description = "Màu sắc sản phẩm đa dạng, thiết kế form dáng trẻ trung\r\n\r\nCó thiết kế túi đựng nhỏ gọn, dễ dàng mang theo sản phẩm\r\n\r\nSiêu nhẹ, có tác dụng giữ ấm cho cơ thể\r\n\r\nChống thấm nước, tránh mưa nhẹ, chống tĩnh điện\r\n\r\nYODY - Look good. Feel good",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phao-Nam-Sieu-Nhe-Co-Mu-Sieu-Am-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phao-Nam-Sieu-Nhe-Co-Mu-Sieu-Am-2.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Phao-Nam-Sieu-Nhe-Co-Mu-Sieu-Am-3.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Ao-Phao-Nam-Sieu-Nhe-Co-Mu-Sieu-Am"
                },
                new Models.Product
                {
                    Id = 18,
                    Name = "Quần Short Nam Ống Rộng Thoáng Mát",
                    Price = 200000,
                    Description = "Quần short nam thể thao YODY\r\n\r\nChất liệu mềm mại, nhẹ nhàng phù hợp vận động\r\n\r\nThiết kế thể thao, khỏe khoắn. Cạp chun cả vòng bản to vô cùng khỏe khoắn\r\n\r\nDây rút chất lượng bền đẹp\r\n\r\nTúi cạnh sườn có khóa kéo để đồ tiện lợi \r\n\r\nYODY - Look good. Feel good.",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-Nam-Ong-Rong-Thoang-Mat-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-Nam-Ong-Rong-Thoang-Mat-2.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-Nam-Ong-Rong-Thoang-Mat-3.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Quan-Short-Nam-Ong-Rong-Thoang-Mat"
                },
                new Models.Product
                {
                    Id = 19,
                    Name = "Quần Short Thể Thao Nam Phối Cạp",
                    Price = 400000,
                    Description = "Quần short gió nam thể thao ngang gối\r\n\r\nThiết kế cơ bản có dây rút, dễ dàng điều chỉnh theo số đo cơ thể\r\n\r\nBản cạp chun to chắc chắn có phối chun thoải mái, không hằn bụng\r\n\r\nMiệng túi có khóa vô cùng tiện lợi cho việc đựng đồ\r\n\r\nSản phẩm phù hợp cho nhiều độ tuồi và sử dụng được cho nhiều hoàn cảnh khác nhau\r\n\r\nYODY - Look good. Feel good.",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-The-Thao-Nam-Phoi-Cap-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-The-Thao-Nam-Phoi-Cap-2.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-The-Thao-Nam-Phoi-Cap-3.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Quan-Short-The-Thao-Nam-Phoi-Cap"
                },
                new Models.Product
                {
                    Id = 20,
                    Name = "Quần Short Nam Kaki Ống Đứng Lịch Lãm",
                    Price = 350000,
                    Description = "Chất liệu Kaki mềm nhẹ, thoải mái\r\n\r\nQuần short nam thiết kế cơ bản dài ngang gối\r\n\r\nCạp quần to bản có đỉa tiện lợi\r\n\r\nTúi cúc phía sau có thể đựng đồ nhỏ gọn như ví, chìa khóa\r\n\r\nPhom dáng trẻ trung, lịch lãm tạo sự chỉn chu, thích hợp mặc ở nhà hay ra ngoài cafe, hẹn hò\r\n\r\nSản phẩm basic dành cho mọi chàng trai\r\n\r\nYODY - Look good. Feel good.",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-Nam-Kaki-Ong-DJung-Lich-Lam-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-Nam-Kaki-Ong-DJung-Lich-Lam-2.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Quan-Short-Nam-Kaki-Ong-DJung-Lich-Lam-3.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Quan-Short-Nam-Kaki-Ong-DJung-Lich-Lam"
                },
                new Models.Product
                {
                    Id = 21,
                    Name = "Áo Len Nam Tay Dài Cổ V Kẻ Sọc Form Regular",
                    Price = 540000,
                    Description = "Với sự phát triển của thời trang, áo len đang ngày một được cải tiến và đa dạng về thiết kế hơn để trở thành thường phục hàng ngày. Ngoài những kiểu dáng truyền thống, các nhãn hàng thời trang đã không ngừng tạo ra nhiều kiểu dáng độc lạ, mới mẽ hơn để các tín đồ áo len thỏa sức lựa chọn cho mình một item phù hợp nhất.\r\n\r\nÁo Dệt Kim Tay Dài Cổ Tròn Phối Sọc. Regular - 10F22KNI010 có form áo Regular với đặc trưng là phần áo suông thẳng không quá rộng giúp phái mạnh có thể che được những điểm mà bản thân chưa tự tin nhưng không mang lại cảm giác lùng bùng. Hơn nữa, với điểm nhấn là màu sắc được phối một cách tinh tế, hài hoà đã giúp mẫu áo với thiết kế cổ tròn, tay dài basic này trở nên vừa dễ phối đồ vừa không mang cảm giác đơn điệu. Đặc biệt, khả năng giữ ấm cũng như nhanh khô của chất liệu acrylic sẽ là lựa chọn tuyệt vời với khí hậu lạnh ẩm trong mùa thu đông.",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Len-Nam-Tay-Dai-Co-V-Ke-Soc-Form-Regular-1.jpeg",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Len-Nam-Tay-Dai-Co-V-Ke-Soc-Form-Regular-2.jpeg",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Len-Nam-Tay-Dai-Co-V-Ke-Soc-Form-Regular-3.jpeg",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Len-Nam-Tay-Dai-Co-V-Ke-Soc-Form-Regular-4.jpeg"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Ao-Len-Nam-Tay-Dai-Co-V-Ke-Soc-Form-Regular"
                },
                new Models.Product
                {
                    Id = 22,
                    Name = "Áo Len Dệt Kim Tay Dài Cổ Tròn Phối Sọc Hiện Đại",
                    Price = 679000,
                    Description = "Với sự phát triển của thời trang, áo len đang ngày một được cải tiến và đa dạng về thiết kế hơn để trở thành thường phục hàng ngày. Ngoài những kiểu dáng truyền thống, các nhãn hàng thời trang đã không ngừng tạo ra nhiều kiểu dáng độc lạ, mới mẽ hơn để các tín đồ áo len thỏa sức lựa chọn cho mình một item phù hợp nhất.\r\n\r\nÁo Dệt Kim Tay Dài Cổ Tròn Phối Sọc. Regular - 10F22KNI010 có form áo Regular với đặc trưng là phần áo suông thẳng không quá rộng giúp phái mạnh có thể che được những điểm mà bản thân chưa tự tin nhưng không mang lại cảm giác lùng bùng. Hơn nữa, với điểm nhấn là màu sắc được phối một cách tinh tế, hài hoà đã giúp mẫu áo với thiết kế cổ tròn, tay dài basic này trở nên vừa dễ phối đồ vừa không mang cảm giác đơn điệu. Đặc biệt, khả năng giữ ấm cũng như nhanh khô của chất liệu acrylic sẽ là lựa chọn tuyệt vời với khí hậu lạnh ẩm trong mùa thu đông.",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Len-Det-Kim-Tay-Dai-Co-Tron-Phoi-Soc-Hien-DJai-1.jpeg",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Len-Det-Kim-Tay-Dai-Co-Tron-Phoi-Soc-Hien-DJai-2.jpeg",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/Ao-Len-Det-Kim-Tay-Dai-Co-Tron-Phoi-Soc-Hien-DJai-3.jpeg"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "Ao-Len-Det-Kim-Tay-Dai-Co-Tron-Phoi-Soc-Hien-DJai"
                },
                new Models.Product
                {
                    Id = 23,
                    Name = "T-Shirt Nam Dáng Rộng In Chữ Ngực",
                    Price = 244000,
                    Description = "Áo thun nam 100% Cotton thân thiện - lành tính\r\n\r\nThành phần:  100% Cotton\r\n\r\nVải Cotton Compact được dệt từ sợi bông USA sạch, góp phần bảo vệ môi trường sống\r\n\r\nÁo có khả năng co giãn đàn hồi, thấm hút mồ hôi tốt, thoáng mát, rất thích hợp với thời tiết nóng ẩm việt Nam\r\n\r\nThiết kế cá tính - trẻ trung - hiện đại, thoải mái cho phối đồ của bạn sáng tạo và phá cách\r\n\r\nKhuyến cáo Giặt sản phẩm trước khi mặc\r\n\r\nYODY - Look good. Feel good.",
                    Image = new string[]
                    {
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/T-Shirt-Nam-Dang-Rong-In-Chu-Nguc-1.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/T-Shirt-Nam-Dang-Rong-In-Chu-Nguc-2.webp",
                        "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/product/T-Shirt-Nam-Dang-Rong-In-Chu-Nguc-3.webp"
                    },
                    View = 0,
                    Sold = 0,
                    IsActive = true,
                    DiscountId = null,
                    CollectionId = null,
                    Slug = "T-Shirt-Nam-Dang-Rong-In-Chu-Nguc"
                });
            modelBuilder.Entity<HaveTag>().HasData(
                new HaveTag { Id = 1, ProductId = 1, TagId = 6 },
                new HaveTag { Id = 2, ProductId = 1, TagId = 7 },
                new HaveTag { Id = 3, ProductId = 2, TagId = 10 },
                new HaveTag { Id = 4, ProductId = 3, TagId = 3 },
                new HaveTag { Id = 5, ProductId = 3, TagId = 4 },
                new HaveTag { Id = 6, ProductId = 4, TagId = 7 },
                new HaveTag { Id = 7, ProductId = 4, TagId = 6 },
                new HaveTag { Id = 8, ProductId = 5, TagId = 6 },
                new HaveTag { Id = 9, ProductId = 5, TagId = 7 },
                new HaveTag { Id = 10, ProductId = 6, TagId = 5 },
                new HaveTag { Id = 11, ProductId = 7, TagId = 9 },
                new HaveTag { Id = 12, ProductId = 8, TagId = 5 },
                new HaveTag { Id = 13, ProductId = 9, TagId = 4 },
                new HaveTag { Id = 14, ProductId = 10, TagId = 7 },
                new HaveTag { Id = 15, ProductId = 11, TagId = 7 },
                new HaveTag { Id = 16, ProductId = 12, TagId = 1 },
                new HaveTag { Id = 17, ProductId = 12, TagId = 3 },
                new HaveTag { Id = 18, ProductId = 13, TagId = 1 },
                new HaveTag { Id = 19, ProductId = 13, TagId = 3 },
                new HaveTag { Id = 20, ProductId = 14, TagId = 1 },
                new HaveTag { Id = 21, ProductId = 14, TagId = 9 },
                new HaveTag { Id = 22, ProductId = 15, TagId = 1 },
                new HaveTag { Id = 23, ProductId = 16, TagId = 1 },
                new HaveTag { Id = 24, ProductId = 17, TagId = 9 },
                new HaveTag { Id = 25, ProductId = 17, TagId = 1 },
                new HaveTag { Id = 26, ProductId = 18, TagId = 8 },
                new HaveTag { Id = 27, ProductId = 19, TagId = 8 },
                new HaveTag { Id = 28, ProductId = 20, TagId = 8 },
                new HaveTag { Id = 29, ProductId = 20, TagId = 4 },
                new HaveTag { Id = 30, ProductId = 21, TagId = 13 },
                new HaveTag { Id = 31, ProductId = 21, TagId = 2 },
                new HaveTag { Id = 32, ProductId = 22, TagId = 3 },
                new HaveTag { Id = 33, ProductId = 23, TagId = 4 }
                );
            modelBuilder.Entity<ProductItem>().HasData(
                new ProductItem { Id = 1, Color = "Cam", Size = "S", Quantity = 10, Image = null, ProductId = 3 },
                new ProductItem { Id = 2, Color = "Cam", Size = "M", Quantity = 10, Image = null, ProductId = 3 },
                new ProductItem { Id = 3, Color = "Cam", Size = "L", Quantity = 10, Image = null, ProductId = 3 },
                new ProductItem { Id = 4, Color = "Cam", Size = "XL", Quantity = 10, Image = null, ProductId = 3 },
                new ProductItem { Id = 5, Color = "Cam", Size = "XXL", Quantity = 10, Image = null, ProductId = 3 },
                new ProductItem { Id = 6, Color = "Xanh", Size = "S", Quantity = 10, Image = null, ProductId = 10 },
                new ProductItem { Id = 7, Color = "Xanh", Size = "M", Quantity = 10, Image = null, ProductId = 10 },
                new ProductItem { Id = 8, Color = "Xanh", Size = "L", Quantity = 10, Image = null, ProductId = 10 },
                new ProductItem { Id = 9, Color = "Xanh", Size = "XL", Quantity = 10, Image = null, ProductId = 10 },
                new ProductItem { Id = 10, Color = "Xanh", Size = "XXL", Quantity = 10, Image = null, ProductId = 10 },
                new ProductItem { Id = 11, Color = "Hồng", Size = "S", Quantity = 10, Image = null, ProductId = 2 },
                new ProductItem { Id = 12, Color = "Hồng", Size = "M", Quantity = 10, Image = null, ProductId = 2 },
                new ProductItem { Id = 13, Color = "Hồng", Size = "L", Quantity = 10, Image = null, ProductId = 2 },
                new ProductItem { Id = 14, Color = "Hồng", Size = "XL", Quantity = 10, Image = null, ProductId = 2 },
                new ProductItem { Id = 15, Color = "Hồng", Size = "XXL", Quantity = 10, Image = null, ProductId = 2 },
                new ProductItem { Id = 16, Color = "Hồng", Size = "S", Quantity = 10, Image = null, ProductId = 11 },
                new ProductItem { Id = 17, Color = "Hồng", Size = "M", Quantity = 10, Image = null, ProductId = 11 },
                new ProductItem { Id = 18, Color = "Hồng", Size = "L", Quantity = 10, Image = null, ProductId = 11 },
                new ProductItem { Id = 19, Color = "Hồng", Size = "XL", Quantity = 10, Image = null, ProductId = 11 },
                new ProductItem { Id = 20, Color = "Hồng", Size = "XXL", Quantity = 10, Image = null, ProductId = 11 },
                new ProductItem { Id = 21, Color = "Kem", Size = "S", Quantity = 10, Image = null, ProductId = 21 },
                new ProductItem { Id = 22, Color = "Kem", Size = "M", Quantity = 10, Image = null, ProductId = 21 },
                new ProductItem { Id = 23, Color = "Kem", Size = "L", Quantity = 10, Image = null, ProductId = 21 },
                new ProductItem { Id = 24, Color = "Kem", Size = "XL", Quantity = 10, Image = null, ProductId = 21 },
                new ProductItem { Id = 25, Color = "Kem", Size = "XXL", Quantity = 10, Image = null, ProductId = 21 },
                new ProductItem { Id = 26, Color = "Nâu", Size = "S", Quantity = 10, Image = null, ProductId = 8 },
                new ProductItem { Id = 27, Color = "Nâu", Size = "M", Quantity = 10, Image = null, ProductId = 8 },
                new ProductItem { Id = 28, Color = "Nâu", Size = "L", Quantity = 10, Image = null, ProductId = 8 },
                new ProductItem { Id = 29, Color = "Nâu", Size = "XL", Quantity = 10, Image = null, ProductId = 8 },
                new ProductItem { Id = 30, Color = "Nâu", Size = "XXL", Quantity = 10, Image = null, ProductId = 8 },
                new ProductItem { Id = 31, Color = "Nâu", Size = "S", Quantity = 10, Image = null, ProductId = 2 },
                new ProductItem { Id = 32, Color = "Nâu", Size = "M", Quantity = 10, Image = null, ProductId = 2 },
                new ProductItem { Id = 33, Color = "Nâu", Size = "L", Quantity = 10, Image = null, ProductId = 2 },
                new ProductItem { Id = 34, Color = "Nâu", Size = "XL", Quantity = 10, Image = null, ProductId = 2 },
                new ProductItem { Id = 35, Color = "Nâu", Size = "XXL", Quantity = 10, Image = null, ProductId = 2 },
                new ProductItem { Id = 36, Color = "Trắng", Size = "S", Quantity = 10, Image = null, ProductId = 5 },
                new ProductItem { Id = 37, Color = "Trắng", Size = "M", Quantity = 10, Image = null, ProductId = 5 },
                new ProductItem { Id = 38, Color = "Trắng", Size = "L", Quantity = 10, Image = null, ProductId = 5 },
                new ProductItem { Id = 39, Color = "Trắng", Size = "XL", Quantity = 10, Image = null, ProductId = 5 },
                new ProductItem { Id = 40, Color = "Trắng", Size = "XXL", Quantity = 10, Image = null, ProductId = 5 },
                new ProductItem { Id = 41, Color = "Trắng", Size = "S", Quantity = 10, Image = null, ProductId = 16 },
                new ProductItem { Id = 42, Color = "Trắng", Size = "M", Quantity = 10, Image = null, ProductId = 16 },
                new ProductItem { Id = 43, Color = "Trắng", Size = "L", Quantity = 10, Image = null, ProductId = 16 },
                new ProductItem { Id = 44, Color = "Trắng", Size = "XL", Quantity = 10, Image = null, ProductId = 16 },
                new ProductItem { Id = 45, Color = "Trắng", Size = "XXL", Quantity = 10, Image = null, ProductId = 16 },
                new ProductItem { Id = 46, Color = "Trắng", Size = "S", Quantity = 10, Image = null, ProductId = 11 },
                new ProductItem { Id = 47, Color = "Trắng", Size = "M", Quantity = 10, Image = null, ProductId = 11 },
                new ProductItem { Id = 48, Color = "Trắng", Size = "L", Quantity = 10, Image = null, ProductId = 11 },
                new ProductItem { Id = 49, Color = "Trắng", Size = "XL", Quantity = 10, Image = null, ProductId = 11 },
                new ProductItem { Id = 50, Color = "Trắng", Size = "XXL", Quantity = 10, Image = null, ProductId = 11 },
                new ProductItem { Id = 51, Color = "Trắng", Size = "S", Quantity = 10, Image = null, ProductId = 10 },
                new ProductItem { Id = 52, Color = "Trắng", Size = "M", Quantity = 10, Image = null, ProductId = 10 },
                new ProductItem { Id = 53, Color = "Trắng", Size = "L", Quantity = 10, Image = null, ProductId = 10 },
                new ProductItem { Id = 54, Color = "Trắng", Size = "XL", Quantity = 10, Image = null, ProductId = 10 },
                new ProductItem { Id = 55, Color = "Trắng", Size = "XXL", Quantity = 10, Image = null, ProductId = 10 },
                new ProductItem { Id = 56, Color = "Trắng", Size = "S", Quantity = 10, Image = null, ProductId = 20 },
                new ProductItem { Id = 57, Color = "Trắng", Size = "M", Quantity = 10, Image = null, ProductId = 20 },
                new ProductItem { Id = 58, Color = "Trắng", Size = "L", Quantity = 10, Image = null, ProductId = 20 },
                new ProductItem { Id = 59, Color = "Trắng", Size = "XL", Quantity = 10, Image = null, ProductId = 20 },
                new ProductItem { Id = 60, Color = "Trắng", Size = "XXL", Quantity = 10, Image = null, ProductId = 20 },
                new ProductItem { Id = 61, Color = "Trắng", Size = "S", Quantity = 10, Image = null, ProductId = 1 },
                new ProductItem { Id = 62, Color = "Trắng", Size = "M", Quantity = 10, Image = null, ProductId = 1 },
                new ProductItem { Id = 63, Color = "Trắng", Size = "L", Quantity = 10, Image = null, ProductId = 1 },
                new ProductItem { Id = 64, Color = "Trắng", Size = "XL", Quantity = 10, Image = null, ProductId = 1 },
                new ProductItem { Id = 65, Color = "Trắng", Size = "XXL", Quantity = 10, Image = null, ProductId = 1 },
                new ProductItem { Id = 66, Color = "Trắng", Size = "S", Quantity = 10, Image = null, ProductId = 3 },
                new ProductItem { Id = 67, Color = "Trắng", Size = "M", Quantity = 10, Image = null, ProductId = 3 },
                new ProductItem { Id = 68, Color = "Trắng", Size = "L", Quantity = 10, Image = null, ProductId = 3 },
                new ProductItem { Id = 69, Color = "Trắng", Size = "XL", Quantity = 10, Image = null, ProductId = 3 },
                new ProductItem { Id = 70, Color = "Trắng", Size = "XXL", Quantity = 10, Image = null, ProductId = 3 },
                new ProductItem { Id = 71, Color = "Trắng", Size = "S", Quantity = 10, Image = null, ProductId = 2 },
                new ProductItem { Id = 72, Color = "Trắng", Size = "M", Quantity = 10, Image = null, ProductId = 2 },
                new ProductItem { Id = 73, Color = "Trắng", Size = "L", Quantity = 10, Image = null, ProductId = 2 },
                new ProductItem { Id = 74, Color = "Trắng", Size = "XL", Quantity = 10, Image = null, ProductId = 2 },
                new ProductItem { Id = 75, Color = "Trắng", Size = "XXL", Quantity = 10, Image = null, ProductId = 2 },
                new ProductItem { Id = 76, Color = "Trắng", Size = "S", Quantity = 10, Image = null, ProductId = 14 },
                new ProductItem { Id = 77, Color = "Trắng", Size = "M", Quantity = 10, Image = null, ProductId = 14 },
                new ProductItem { Id = 78, Color = "Trắng", Size = "L", Quantity = 10, Image = null, ProductId = 14 },
                new ProductItem { Id = 79, Color = "Trắng", Size = "XL", Quantity = 10, Image = null, ProductId = 14 },
                new ProductItem { Id = 80, Color = "Trắng", Size = "XXL", Quantity = 10, Image = null, ProductId = 14 },
                new ProductItem { Id = 81, Color = "Tím", Size = "S", Quantity = 10, Image = null, ProductId = 5 },
                new ProductItem { Id = 82, Color = "Tím", Size = "M", Quantity = 10, Image = null, ProductId = 5 },
                new ProductItem { Id = 83, Color = "Tím", Size = "L", Quantity = 10, Image = null, ProductId = 5 },
                new ProductItem { Id = 84, Color = "Tím", Size = "XL", Quantity = 10, Image = null, ProductId = 5 },
                new ProductItem { Id = 85, Color = "Tím", Size = "XXL", Quantity = 10, Image = null, ProductId = 5 },
                new ProductItem { Id = 86, Color = "Xanh", Size = "S", Quantity = 10, Image = null, ProductId = 11 },
                new ProductItem { Id = 87, Color = "Xanh", Size = "M", Quantity = 10, Image = null, ProductId = 11 },
                new ProductItem { Id = 88, Color = "Xanh", Size = "L", Quantity = 10, Image = null, ProductId = 11 },
                new ProductItem { Id = 89, Color = "Xanh", Size = "XL", Quantity = 10, Image = null, ProductId = 11 },
                new ProductItem { Id = 90, Color = "Xanh", Size = "XXL", Quantity = 10, Image = null, ProductId = 11 },
                new ProductItem { Id = 91, Color = "Xanh", Size = "S", Quantity = 10, Image = null, ProductId = 9 },
                new ProductItem { Id = 92, Color = "Xanh", Size = "M", Quantity = 10, Image = null, ProductId = 9 },
                new ProductItem { Id = 93, Color = "Xanh", Size = "L", Quantity = 10, Image = null, ProductId = 9 },
                new ProductItem { Id = 94, Color = "Xanh", Size = "XL", Quantity = 10, Image = null, ProductId = 9 },
                new ProductItem { Id = 95, Color = "Xanh", Size = "XXL", Quantity = 10, Image = null, ProductId = 9 },
                new ProductItem { Id = 96, Color = "Xanh", Size = "S", Quantity = 10, Image = null, ProductId = 3 },
                new ProductItem { Id = 97, Color = "Xanh", Size = "M", Quantity = 10, Image = null, ProductId = 3 },
                new ProductItem { Id = 98, Color = "Xanh", Size = "L", Quantity = 10, Image = null, ProductId = 3 },
                new ProductItem { Id = 99, Color = "Xanh", Size = "XL", Quantity = 10, Image = null, ProductId = 3 },
                new ProductItem { Id = 100, Color = "Xanh", Size = "XXL", Quantity = 10, Image = null, ProductId = 3 },
                new ProductItem { Id = 101, Color = "Xanh", Size = "S", Quantity = 10, Image = null, ProductId = 18 },
                new ProductItem { Id = 102, Color = "Xanh", Size = "M", Quantity = 10, Image = null, ProductId = 18 },
                new ProductItem { Id = 103, Color = "Xanh", Size = "L", Quantity = 10, Image = null, ProductId = 18 },
                new ProductItem { Id = 104, Color = "Xanh", Size = "XL", Quantity = 10, Image = null, ProductId = 18 },
                new ProductItem { Id = 105, Color = "Xanh", Size = "XXL", Quantity = 10, Image = null, ProductId = 18 },
                new ProductItem { Id = 106, Color = "Xanh", Size = "S", Quantity = 10, Image = null, ProductId = 19 },
                new ProductItem { Id = 107, Color = "Xanh", Size = "M", Quantity = 10, Image = null, ProductId = 19 },
                new ProductItem { Id = 108, Color = "Xanh", Size = "L", Quantity = 10, Image = null, ProductId = 19 },
                new ProductItem { Id = 109, Color = "Xanh", Size = "XL", Quantity = 10, Image = null, ProductId = 19 },
                new ProductItem { Id = 110, Color = "Xanh", Size = "XXL", Quantity = 10, Image = null, ProductId = 19 },
                new ProductItem { Id = 116, Color = "Xanh", Size = "S", Quantity = 10, Image = null, ProductId = 8 },
                new ProductItem { Id = 117, Color = "Xanh", Size = "M", Quantity = 10, Image = null, ProductId = 8 },
                new ProductItem { Id = 118, Color = "Xanh", Size = "L", Quantity = 10, Image = null, ProductId = 8 },
                new ProductItem { Id = 119, Color = "Xanh", Size = "XL", Quantity = 10, Image = null, ProductId = 8 },
                new ProductItem { Id = 120, Color = "Xanh", Size = "XXL", Quantity = 10, Image = null, ProductId = 8 },
                new ProductItem { Id = 121, Color = "Xanh", Size = "S", Quantity = 10, Image = null, ProductId = 6 },
                new ProductItem { Id = 122, Color = "Xanh", Size = "M", Quantity = 10, Image = null, ProductId = 6 },
                new ProductItem { Id = 123, Color = "Xanh", Size = "L", Quantity = 10, Image = null, ProductId = 6 },
                new ProductItem { Id = 124, Color = "Xanh", Size = "XL", Quantity = 10, Image = null, ProductId = 6 },
                new ProductItem { Id = 125, Color = "Xanh", Size = "XXL", Quantity = 10, Image = null, ProductId = 6 },
                new ProductItem { Id = 126, Color = "Xanh", Size = "S", Quantity = 10, Image = null, ProductId = 13 },
                new ProductItem { Id = 127, Color = "Xanh", Size = "M", Quantity = 10, Image = null, ProductId = 13 },
                new ProductItem { Id = 128, Color = "Xanh", Size = "L", Quantity = 10, Image = null, ProductId = 13 },
                new ProductItem { Id = 129, Color = "Xanh", Size = "XL", Quantity = 10, Image = null, ProductId = 13 },
                new ProductItem { Id = 130, Color = "Xanh", Size = "XXL", Quantity = 10, Image = null, ProductId = 13 }
                );
            modelBuilder.Entity<Voucher>().HasData(
                new Voucher { Code = "ABCDEF", Name = "Khuyến mãi 1", Discount = 20, Description = "", Due = new DateOnly(2023, 12, 31), IsActive = true },
                new Voucher { Code = "ABC123", Name = "Khuyến mãi 2", Discount = 5, Description = "", Due = new DateOnly(2023, 12, 31), IsActive = false }
                );
        }
    }
}

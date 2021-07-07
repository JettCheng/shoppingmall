using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Database.Domain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProductTypeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OriginalPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Level", "Name", "ParentId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "FA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "流行時尚", "", null, null },
                    { "ME16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "汽車", "ME", null, null },
                    { "CA15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "運動休閒", "CA", null, null },
                    { "CA14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "玩具", "CA", null, null },
                    { "CA13", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "零食", "CA", null, null },
                    { "CA12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "寵物用品", "CA", null, null },
                    { "CA11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "單眼攝影", "CA", null, null },
                    { "TE10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "手機平板", "TE", null, null },
                    { "TE09", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "電腦3C", "TE", null, null },
                    { "LI08", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "居家生活", "LI", null, null },
                    { "ME17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "汽機車零件", "ME", null, null },
                    { "LI07", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "家電用品", "LI", null, null },
                    { "LI05", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "圖書", "LI", null, null },
                    { "FA04", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "名牌精品", "FA", null, null },
                    { "FA03", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "美妝保養", "FA", null, null },
                    { "FA02", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "女士時尚", "FA", null, null },
                    { "FA01", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "男士時尚", "FA", null, null },
                    { "ME", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "汽車房屋", "", null, null },
                    { "CA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "休閒良品", "", null, null },
                    { "TE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "科技", "", null, null },
                    { "LI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "生活家居", "", null, null },
                    { "LI06", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "親子用品", "LI", null, null },
                    { "ME18", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "機車", "ME", null, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "Description", "OriginalPrice", "ProductTypeId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("88dfcf99-43e4-4823-b88b-0cff516a5c38"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3500.0, "FA02", 1, "秋季女時尚短褲", null, null },
                    { new Guid("65c5da59-0427-424c-a610-02793217e6a0"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 500.0, "CA11", 0, "單眼相機", null, null },
                    { new Guid("35cc7908-ad9f-4211-8668-fb8a2954134d"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3300.0, "CA11", 2, "移動式小型攝影棚", null, null },
                    { new Guid("50175acc-dfbf-43ac-86aa-aee37f804f5c"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3600.0, "CA11", 1, "移動時遙控補光燈", null, null },
                    { new Guid("1808d7cf-405a-4302-9944-f1767f5ab9ff"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1400.0, "CA11", 0, "離地飛行 空拍機", null, null },
                    { new Guid("94fd8580-d2dc-42ac-a29a-d7a855e74a80"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 4900.0, "CA12", 2, "狗狗項圈", null, null },
                    { new Guid("5f2ae358-c830-4d59-addf-db8db428d87f"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 300.0, "CA12", 1, "逗貓棒", null, null },
                    { new Guid("f9aabc94-e10a-4fbe-9cf3-92fc0f6e7a73"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 100.0, "CA12", 0, "狗狗最愛吃的橡膠骨頭", null, null },
                    { new Guid("1f757f9c-b268-41bd-8749-f995cbb468ea"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2700.0, "CA13", 2, "義美泡芙", null, null },
                    { new Guid("b065f698-e3b6-42d0-8534-75f6d27618e7"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2400.0, "CA14", 0, "益智拼圖", null, null },
                    { new Guid("bce11432-c2a8-4ad2-a49c-2a44bfe6a16d"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1500.0, "CA14", 2, "樂高積木組", null, null },
                    { new Guid("5a27d0b2-e094-47ca-9a99-1b825439f107"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3000.0, "CA14", 2, "芭比娃娃組", null, null },
                    { new Guid("299e65a7-5827-49b1-b08d-df237a7b01a7"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2300.0, "CA15", 2, "飛盤", null, null },
                    { new Guid("6b62b0f7-45a8-4032-8aeb-402af3ae8406"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1500.0, "CA15", 0, "籃球", null, null },
                    { new Guid("6050fe69-74d3-4f50-9fc4-a78c4fc72609"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2900.0, "CA15", 0, "滑板", null, null },
                    { new Guid("907deaf0-cba5-491e-ab42-a20bbaaa040b"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 4200.0, "ME16", 1, "不安全的電動汽車", null, null },
                    { new Guid("02d9d1f8-2761-429d-b47f-1d45f62b1802"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 4900.0, "ME16", 2, "時速3公里的超安全電動汽車", null, null },
                    { new Guid("bc169dab-5c24-4fd5-af97-5e4a27121f69"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1300.0, "ME17", 1, "機車手機架", null, null },
                    { new Guid("326ad98f-948c-4081-95c3-298dfe46a705"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2500.0, "ME17", 2, "機車車廂內襯", null, null },
                    { new Guid("54d5e86b-f4fc-43a8-8fbf-a3d3733f6d85"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2000.0, "ME17", 0, "車用吸塵器", null, null },
                    { new Guid("3eac1cc3-3166-4d1d-a8f0-59d32f0468be"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1200.0, "ME17", 1, "半罩安全帽", null, null },
                    { new Guid("edbc6b1c-5e84-4127-bce3-67fb47bc11e4"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1600.0, "ME17", 2, "全罩安全帽", null, null },
                    { new Guid("8da96b9e-91fa-4f84-bef0-e162eded6b29"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 500.0, "TE10", 1, "ipad 2", null, null },
                    { new Guid("3b29be19-ce96-46ce-8dc5-c6bf34a02530"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3300.0, "TE10", 2, "HTC TOW", null, null },
                    { new Guid("6e33b0fb-300b-470a-a6f2-978a580bdddf"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1500.0, "TE10", 2, "Iphone13", null, null },
                    { new Guid("43f51afb-b935-48fb-893e-90dc3088a73f"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 4200.0, "TE10", 2, "macbook air m1", null, null },
                    { new Guid("4b898315-cb1a-42b1-8a16-71f7e7a422d7"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 600.0, "FA02", 2, "運動健身內衣", null, null },
                    { new Guid("c3773ce0-19aa-4e5e-8bd1-b579ff85c426"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1200.0, "FA02", 1, "時尚洋裝", null, null },
                    { new Guid("67a82b71-b359-48d2-84aa-fe4a6cd9be80"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1000.0, "FA03", 1, "夜間保濕面霜", null, null },
                    { new Guid("d36210e7-e4c2-4826-b288-5a8f67ca5793"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 5000.0, "FA03", 0, "超保濕面膜", null, null },
                    { new Guid("2513250e-261d-4efa-b874-83cd1267c8ce"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 500.0, "FA04", 2, "GUCCI 銀釦斜格紋PVC托特包(卡其棕)", null, null },
                    { new Guid("7854cc1b-64ab-4062-aa0f-ba02aeb36ce6"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 500.0, "FA04", 2, "COACH 精品手提包", null, null },
                    { new Guid("945ce915-201f-4605-b4cd-8db15ca5836b"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1400.0, "FA04", 0, "COUCH 精品沙發", null, null },
                    { new Guid("4226947b-a632-45b1-9e3d-28b708fa91a9"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 500.0, "FA04", 2, "GINPIN 精品後背包", null, null },
                    { new Guid("57f7fce4-1f00-4da9-bd57-2e1c30b1260a"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3900.0, "FA04", 2, "NAPON 精品手提包", null, null },
                    { new Guid("6d540f22-1587-4b73-bfd0-a467ae00ac22"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3800.0, "FA04", 2, "PINWEN 精品電腦包", null, null },
                    { new Guid("2d8fbdae-3835-4d03-8d20-924c1f6f6910"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1000.0, "ME18", 2, "YAMAHA RS 7", null, null },
                    { new Guid("438838e4-ef46-4f60-af23-b8060c52ce78"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 600.0, "FA04", 2, "QUEEN 真皮電腦包", null, null },
                    { new Guid("b285cf2b-55ea-4d7a-acf3-3f32ae27f195"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2100.0, "LI05", 1, "古文觀止", null, null },
                    { new Guid("ce72684b-569f-4427-a539-f71f4c134372"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 400.0, "LI06", 2, "電子嬰兒磅秤", null, null },
                    { new Guid("2a6557e9-7727-4854-9ac6-44756849bd41"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1600.0, "LI06", 2, "嬰兒床邊收納袋", null, null },
                    { new Guid("a8238610-ba6a-44eb-a229-c1f90647bcf3"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1700.0, "LI06", 2, "多功能變形圍欄式嬰兒床", null, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "Description", "OriginalPrice", "ProductTypeId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("f0cb29ba-76d0-4737-8565-5de26e4c24e4"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3000.0, "LI06", 1, "安撫遊戲床", null, null },
                    { new Guid("22c4b828-0c4d-42ae-9c9e-d339c1fa951d"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3900.0, "LI06", 0, "木質相機乳牙保存盒", null, null },
                    { new Guid("a2bf8a79-705e-47d4-a2bd-44049337d60b"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1200.0, "LI08", 0, "北歐簡約收納盤", null, null },
                    { new Guid("e340e14b-d498-4115-8698-6f7b7a5b8a5f"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3800.0, "LI08", 2, "6666果汁機", null, null },
                    { new Guid("05420a89-ea89-40ca-bc5c-cd12f1afaf09"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3400.0, "LI08", 2, "旋轉飾品盒", null, null },
                    { new Guid("118cda2b-cb82-4749-bd07-3d4bee175bb6"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2200.0, "TE09", 2, "安卓充電線", null, null },
                    { new Guid("f54924cc-8c8a-4afc-869a-d67c89815e8c"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1100.0, "LI05", 2, "屁屁偵探", null, null },
                    { new Guid("9de69a44-fee2-4c0a-b3c9-4d05e14ded8f"), "http://placekitten.com/g/300/300", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1000.0, "ME18", 2, "KIMCO JJ6", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ProductId", "Status", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("88dfcf99-43e4-4823-b88b-0cff516a5c38"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("94fd8580-d2dc-42ac-a29a-d7a855e74a80"), 0, null, null, "http://placekitten.com/g/300/300" },
                    { 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("94fd8580-d2dc-42ac-a29a-d7a855e74a80"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("5f2ae358-c830-4d59-addf-db8db428d87f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("5f2ae358-c830-4d59-addf-db8db428d87f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("5f2ae358-c830-4d59-addf-db8db428d87f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("5f2ae358-c830-4d59-addf-db8db428d87f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f9aabc94-e10a-4fbe-9cf3-92fc0f6e7a73"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f9aabc94-e10a-4fbe-9cf3-92fc0f6e7a73"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 132, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f9aabc94-e10a-4fbe-9cf3-92fc0f6e7a73"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("1f757f9c-b268-41bd-8749-f995cbb468ea"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("1f757f9c-b268-41bd-8749-f995cbb468ea"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("1f757f9c-b268-41bd-8749-f995cbb468ea"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b065f698-e3b6-42d0-8534-75f6d27618e7"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b065f698-e3b6-42d0-8534-75f6d27618e7"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b065f698-e3b6-42d0-8534-75f6d27618e7"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 198, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b065f698-e3b6-42d0-8534-75f6d27618e7"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("bce11432-c2a8-4ad2-a49c-2a44bfe6a16d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("bce11432-c2a8-4ad2-a49c-2a44bfe6a16d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("bce11432-c2a8-4ad2-a49c-2a44bfe6a16d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("bce11432-c2a8-4ad2-a49c-2a44bfe6a16d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("5a27d0b2-e094-47ca-9a99-1b825439f107"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("94fd8580-d2dc-42ac-a29a-d7a855e74a80"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("5a27d0b2-e094-47ca-9a99-1b825439f107"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("94fd8580-d2dc-42ac-a29a-d7a855e74a80"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("1808d7cf-405a-4302-9944-f1767f5ab9ff"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("43f51afb-b935-48fb-893e-90dc3088a73f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("6e33b0fb-300b-470a-a6f2-978a580bdddf"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("6e33b0fb-300b-470a-a6f2-978a580bdddf"), 0, null, null, "http://placekitten.com/g/300/300" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("6e33b0fb-300b-470a-a6f2-978a580bdddf"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("6e33b0fb-300b-470a-a6f2-978a580bdddf"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3b29be19-ce96-46ce-8dc5-c6bf34a02530"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3b29be19-ce96-46ce-8dc5-c6bf34a02530"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3b29be19-ce96-46ce-8dc5-c6bf34a02530"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3b29be19-ce96-46ce-8dc5-c6bf34a02530"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3b29be19-ce96-46ce-8dc5-c6bf34a02530"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8da96b9e-91fa-4f84-bef0-e162eded6b29"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8da96b9e-91fa-4f84-bef0-e162eded6b29"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8da96b9e-91fa-4f84-bef0-e162eded6b29"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("65c5da59-0427-424c-a610-02793217e6a0"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("65c5da59-0427-424c-a610-02793217e6a0"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("65c5da59-0427-424c-a610-02793217e6a0"), 1, null, null, "http://placekitten.com/g/300/300" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ProductId", "Status", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("35cc7908-ad9f-4211-8668-fb8a2954134d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 134, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("35cc7908-ad9f-4211-8668-fb8a2954134d"), 0, null, null, "http://placekitten.com/g/300/300" },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("50175acc-dfbf-43ac-86aa-aee37f804f5c"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 135, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("50175acc-dfbf-43ac-86aa-aee37f804f5c"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("1808d7cf-405a-4302-9944-f1767f5ab9ff"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("1808d7cf-405a-4302-9944-f1767f5ab9ff"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("43f51afb-b935-48fb-893e-90dc3088a73f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("5a27d0b2-e094-47ca-9a99-1b825439f107"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("299e65a7-5827-49b1-b08d-df237a7b01a7"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("54d5e86b-f4fc-43a8-8fbf-a3d3733f6d85"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("54d5e86b-f4fc-43a8-8fbf-a3d3733f6d85"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("54d5e86b-f4fc-43a8-8fbf-a3d3733f6d85"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3eac1cc3-3166-4d1d-a8f0-59d32f0468be"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3eac1cc3-3166-4d1d-a8f0-59d32f0468be"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3eac1cc3-3166-4d1d-a8f0-59d32f0468be"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 156, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3eac1cc3-3166-4d1d-a8f0-59d32f0468be"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("edbc6b1c-5e84-4127-bce3-67fb47bc11e4"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("edbc6b1c-5e84-4127-bce3-67fb47bc11e4"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 137, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("edbc6b1c-5e84-4127-bce3-67fb47bc11e4"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 157, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("edbc6b1c-5e84-4127-bce3-67fb47bc11e4"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2d8fbdae-3835-4d03-8d20-924c1f6f6910"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2d8fbdae-3835-4d03-8d20-924c1f6f6910"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2d8fbdae-3835-4d03-8d20-924c1f6f6910"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2d8fbdae-3835-4d03-8d20-924c1f6f6910"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2d8fbdae-3835-4d03-8d20-924c1f6f6910"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 151, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2d8fbdae-3835-4d03-8d20-924c1f6f6910"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("9de69a44-fee2-4c0a-b3c9-4d05e14ded8f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("9de69a44-fee2-4c0a-b3c9-4d05e14ded8f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("9de69a44-fee2-4c0a-b3c9-4d05e14ded8f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("9de69a44-fee2-4c0a-b3c9-4d05e14ded8f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 154, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("326ad98f-948c-4081-95c3-298dfe46a705"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("299e65a7-5827-49b1-b08d-df237a7b01a7"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("326ad98f-948c-4081-95c3-298dfe46a705"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("326ad98f-948c-4081-95c3-298dfe46a705"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("299e65a7-5827-49b1-b08d-df237a7b01a7"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 195, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("299e65a7-5827-49b1-b08d-df237a7b01a7"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("6b62b0f7-45a8-4032-8aeb-402af3ae8406"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("6b62b0f7-45a8-4032-8aeb-402af3ae8406"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("6b62b0f7-45a8-4032-8aeb-402af3ae8406"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("6b62b0f7-45a8-4032-8aeb-402af3ae8406"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("6050fe69-74d3-4f50-9fc4-a78c4fc72609"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("6050fe69-74d3-4f50-9fc4-a78c4fc72609"), 1, null, null, "http://placekitten.com/g/300/300" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ProductId", "Status", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("6050fe69-74d3-4f50-9fc4-a78c4fc72609"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("6050fe69-74d3-4f50-9fc4-a78c4fc72609"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 197, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("6050fe69-74d3-4f50-9fc4-a78c4fc72609"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("907deaf0-cba5-491e-ab42-a20bbaaa040b"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("907deaf0-cba5-491e-ab42-a20bbaaa040b"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 138, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("907deaf0-cba5-491e-ab42-a20bbaaa040b"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 158, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("907deaf0-cba5-491e-ab42-a20bbaaa040b"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("02d9d1f8-2761-429d-b47f-1d45f62b1802"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("02d9d1f8-2761-429d-b47f-1d45f62b1802"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 139, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("02d9d1f8-2761-429d-b47f-1d45f62b1802"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 159, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("02d9d1f8-2761-429d-b47f-1d45f62b1802"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 168, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("02d9d1f8-2761-429d-b47f-1d45f62b1802"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 153, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("bc169dab-5c24-4fd5-af97-5e4a27121f69"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("326ad98f-948c-4081-95c3-298dfe46a705"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("43f51afb-b935-48fb-893e-90dc3088a73f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("43f51afb-b935-48fb-893e-90dc3088a73f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("118cda2b-cb82-4749-bd07-3d4bee175bb6"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 180, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("7854cc1b-64ab-4062-aa0f-ba02aeb36ce6"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 184, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("7854cc1b-64ab-4062-aa0f-ba02aeb36ce6"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("945ce915-201f-4605-b4cd-8db15ca5836b"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 181, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("945ce915-201f-4605-b4cd-8db15ca5836b"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 185, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("945ce915-201f-4605-b4cd-8db15ca5836b"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4226947b-a632-45b1-9e3d-28b708fa91a9"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 186, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4226947b-a632-45b1-9e3d-28b708fa91a9"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("57f7fce4-1f00-4da9-bd57-2e1c30b1260a"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("57f7fce4-1f00-4da9-bd57-2e1c30b1260a"), 0, null, null, "http://placekitten.com/g/300/300" },
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("57f7fce4-1f00-4da9-bd57-2e1c30b1260a"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 187, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("57f7fce4-1f00-4da9-bd57-2e1c30b1260a"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("6d540f22-1587-4b73-bfd0-a467ae00ac22"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("6d540f22-1587-4b73-bfd0-a467ae00ac22"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("6d540f22-1587-4b73-bfd0-a467ae00ac22"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 188, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("6d540f22-1587-4b73-bfd0-a467ae00ac22"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("438838e4-ef46-4f60-af23-b8060c52ce78"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("438838e4-ef46-4f60-af23-b8060c52ce78"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("438838e4-ef46-4f60-af23-b8060c52ce78"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 189, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("438838e4-ef46-4f60-af23-b8060c52ce78"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f54924cc-8c8a-4afc-869a-d67c89815e8c"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f54924cc-8c8a-4afc-869a-d67c89815e8c"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("7854cc1b-64ab-4062-aa0f-ba02aeb36ce6"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f54924cc-8c8a-4afc-869a-d67c89815e8c"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("7854cc1b-64ab-4062-aa0f-ba02aeb36ce6"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 179, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2513250e-261d-4efa-b874-83cd1267c8ce"), 1, null, null, "http://placekitten.com/g/300/300" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ProductId", "Status", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("88dfcf99-43e4-4823-b88b-0cff516a5c38"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("88dfcf99-43e4-4823-b88b-0cff516a5c38"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 192, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("88dfcf99-43e4-4823-b88b-0cff516a5c38"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4b898315-cb1a-42b1-8a16-71f7e7a422d7"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4b898315-cb1a-42b1-8a16-71f7e7a422d7"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4b898315-cb1a-42b1-8a16-71f7e7a422d7"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 193, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4b898315-cb1a-42b1-8a16-71f7e7a422d7"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c3773ce0-19aa-4e5e-8bd1-b579ff85c426"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c3773ce0-19aa-4e5e-8bd1-b579ff85c426"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c3773ce0-19aa-4e5e-8bd1-b579ff85c426"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 194, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c3773ce0-19aa-4e5e-8bd1-b579ff85c426"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a82b71-b359-48d2-84aa-fe4a6cd9be80"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a82b71-b359-48d2-84aa-fe4a6cd9be80"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a82b71-b359-48d2-84aa-fe4a6cd9be80"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 190, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a82b71-b359-48d2-84aa-fe4a6cd9be80"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("d36210e7-e4c2-4826-b288-5a8f67ca5793"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("d36210e7-e4c2-4826-b288-5a8f67ca5793"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("d36210e7-e4c2-4826-b288-5a8f67ca5793"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 191, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("d36210e7-e4c2-4826-b288-5a8f67ca5793"), 0, null, null, "http://placekitten.com/g/300/300" },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2513250e-261d-4efa-b874-83cd1267c8ce"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2513250e-261d-4efa-b874-83cd1267c8ce"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 183, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2513250e-261d-4efa-b874-83cd1267c8ce"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 177, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f54924cc-8c8a-4afc-869a-d67c89815e8c"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b285cf2b-55ea-4d7a-acf3-3f32ae27f195"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b285cf2b-55ea-4d7a-acf3-3f32ae27f195"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 167, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("22c4b828-0c4d-42ae-9c9e-d339c1fa951d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 176, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("22c4b828-0c4d-42ae-9c9e-d339c1fa951d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a2bf8a79-705e-47d4-a2bd-44049337d60b"), 0, null, null, "http://placekitten.com/g/300/300" },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a2bf8a79-705e-47d4-a2bd-44049337d60b"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a2bf8a79-705e-47d4-a2bd-44049337d60b"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a2bf8a79-705e-47d4-a2bd-44049337d60b"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 169, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a2bf8a79-705e-47d4-a2bd-44049337d60b"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e340e14b-d498-4115-8698-6f7b7a5b8a5f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e340e14b-d498-4115-8698-6f7b7a5b8a5f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 141, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e340e14b-d498-4115-8698-6f7b7a5b8a5f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 161, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e340e14b-d498-4115-8698-6f7b7a5b8a5f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 170, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e340e14b-d498-4115-8698-6f7b7a5b8a5f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("05420a89-ea89-40ca-bc5c-cd12f1afaf09"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("05420a89-ea89-40ca-bc5c-cd12f1afaf09"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("05420a89-ea89-40ca-bc5c-cd12f1afaf09"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 162, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("05420a89-ea89-40ca-bc5c-cd12f1afaf09"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 171, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("05420a89-ea89-40ca-bc5c-cd12f1afaf09"), 1, null, null, "http://placekitten.com/g/300/300" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ProductId", "Status", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("05420a89-ea89-40ca-bc5c-cd12f1afaf09"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("118cda2b-cb82-4749-bd07-3d4bee175bb6"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("118cda2b-cb82-4749-bd07-3d4bee175bb6"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("118cda2b-cb82-4749-bd07-3d4bee175bb6"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 147, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("22c4b828-0c4d-42ae-9c9e-d339c1fa951d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("22c4b828-0c4d-42ae-9c9e-d339c1fa951d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("22c4b828-0c4d-42ae-9c9e-d339c1fa951d"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 175, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f0cb29ba-76d0-4737-8565-5de26e4c24e4"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 149, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b285cf2b-55ea-4d7a-acf3-3f32ae27f195"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 178, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b285cf2b-55ea-4d7a-acf3-3f32ae27f195"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 182, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b285cf2b-55ea-4d7a-acf3-3f32ae27f195"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ce72684b-569f-4427-a539-f71f4c134372"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ce72684b-569f-4427-a539-f71f4c134372"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 143, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ce72684b-569f-4427-a539-f71f4c134372"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 163, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ce72684b-569f-4427-a539-f71f4c134372"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 172, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ce72684b-569f-4427-a539-f71f4c134372"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2a6557e9-7727-4854-9ac6-44756849bd41"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2a6557e9-7727-4854-9ac6-44756849bd41"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("9de69a44-fee2-4c0a-b3c9-4d05e14ded8f"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 144, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2a6557e9-7727-4854-9ac6-44756849bd41"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 173, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2a6557e9-7727-4854-9ac6-44756849bd41"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a8238610-ba6a-44eb-a229-c1f90647bcf3"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a8238610-ba6a-44eb-a229-c1f90647bcf3"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 145, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a8238610-ba6a-44eb-a229-c1f90647bcf3"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 165, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a8238610-ba6a-44eb-a229-c1f90647bcf3"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 174, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a8238610-ba6a-44eb-a229-c1f90647bcf3"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f0cb29ba-76d0-4737-8565-5de26e4c24e4"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f0cb29ba-76d0-4737-8565-5de26e4c24e4"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 146, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f0cb29ba-76d0-4737-8565-5de26e4c24e4"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 166, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f0cb29ba-76d0-4737-8565-5de26e4c24e4"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 164, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2a6557e9-7727-4854-9ac6-44756849bd41"), 1, null, null, "http://placekitten.com/g/300/300" },
                    { 152, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("9de69a44-fee2-4c0a-b3c9-4d05e14ded8f"), 1, null, null, "http://placekitten.com/g/300/300" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}

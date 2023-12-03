using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaLibraryAPI.Migrations
{
    public partial class ShortenDescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Role = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEnglish = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    TitleJapanese = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    ReleaseYear = table.Column<short>(type: "smallint", nullable: false),
                    Bookmark = table.Column<byte>(type: "tinyint", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Mangas_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MangaDetails",
                columns: table => new
                {
                    MangaID = table.Column<int>(type: "int", nullable: false),
                    TitleRomaji = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publishing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Votes = table.Column<int>(type: "int", nullable: false),
                    Volumes = table.Column<short>(type: "smallint", nullable: false),
                    Chapters = table.Column<short>(type: "smallint", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaDetails", x => x.MangaID);
                    table.ForeignKey(
                        name: "FK_MangaDetails_Mangas_MangaID",
                        column: x => x.MangaID,
                        principalTable: "Mangas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Mangas",
                columns: new[] { "ID", "Bookmark", "Poster", "Rating", "ReleaseYear", "ShortDescription", "Status", "TitleEnglish", "TitleJapanese", "UserID" },
                values: new object[,]
                {
                    { 1, (byte)1, "https://cdn.myanimelist.net/images/manga/1/157897.jpg", 9.84f, (short)1989, "Guts, a former mercenary now known as the \"Black Swordsman\", is out for revenge. After a tumultuous childhood, he finally finds someone he respects and believes he can trust, only to have everything fall apart when this person takes away everything...", (byte)3, "Berserk", "ベルセルク", null },
                    { 2, (byte)1, "https://cdn.myanimelist.net/images/manga/3/265854.jpg", 9.36f, (short)2005, "\"Akumajō Dracula: Yami no Juin\" had in Japan its own comic series that lasted all of two volumes. The comic series of the same name was created in 2005 by company Mediafactory, and it follows events that overlap with bonus-material comic...", (byte)4, "Castlevania: Curse of Darkness", "悪魔城ドラキュラ 闇の呪印", null },
                    { 3, (byte)1, "https://cover.imglib.info/uploads/cover/desu-noto/cover/5UcB013CNhll_250x350.jpg", 9.6f, (short)2003, "Ryuk, a god of death, drops his Death Note into the human world for personal pleasure. In Japan, prodigious high school student Light Yagami stumbles upon it. Inside the notebook, he finds a chilling message: those whose names are written in it shall die.", (byte)4, "Death Note", "デスノート", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email", "Name", "Password", "Role" },
                values: new object[] { 1, "obichnichelovek@vk.com", "Admin", "SuperSecretPassword", (byte)2 });

            migrationBuilder.InsertData(
                table: "MangaDetails",
                columns: new[] { "MangaID", "Artist", "Author", "Chapters", "Description", "PublishDate", "Publishing", "TitleRomaji", "UpdateDate", "Volumes", "Votes" },
                values: new object[] { 1, "Kentaro Miura", "Kentaro Miura", (short)376, "Guts, a former mercenary now known as the \"Black Swordsman\", is out for revenge. After a tumultuous childhood, he finally finds someone he respects and believes he can trust, only to have everything fall apart when this person takes away everything important to Guts for the purpose of fulfilling his own desires. Now marked for death, Guts becomes condemned to a fate in which he is relentlessly pursued by demonic beings.\n\nSetting out on a dreadful quest riddled with misfortune, Guts, armed with a massive sword and monstrous strength, will let nothing stop him, not even death itself, until he is finally able to take the head of the one who stripped him—and his loved one—of their humanity.", new DateTime(2023, 12, 3, 8, 52, 18, 412, DateTimeKind.Local).AddTicks(8493), "Hakusensha, Dark Horse Comics, XL Media", "Beruseruku", new DateTime(2023, 12, 3, 8, 52, 18, 412, DateTimeKind.Local).AddTicks(8515), (short)41, 12646 });

            migrationBuilder.InsertData(
                table: "MangaDetails",
                columns: new[] { "MangaID", "Artist", "Author", "Chapters", "Description", "PublishDate", "Publishing", "TitleRomaji", "UpdateDate", "Volumes", "Votes" },
                values: new object[] { 2, "SASAKURA Kou", "SASAKURA Kou", (short)4, "\"Akumajō Dracula: Yami no Juin\" had in Japan its own comic series that lasted all of two volumes. The comic series of the same name was created in 2005 by company Mediafactory, and it follows events that overlap with bonus-material comic Prelude of Revenge, whose story was conceived by Ayami Kojima; the series is, according to her, a true extension of the of both Prelude and therein the game's actual story. Adding to its authenticity is the knowledge that Koji Igarashi completely supervised its creation.", new DateTime(2023, 12, 3, 8, 52, 18, 412, DateTimeKind.Local).AddTicks(8524), "Media Factory", "Akumajō Dracula: Yami no Juin", new DateTime(2023, 12, 3, 8, 52, 18, 412, DateTimeKind.Local).AddTicks(8533), (short)2, 42 });

            migrationBuilder.InsertData(
                table: "MangaDetails",
                columns: new[] { "MangaID", "Artist", "Author", "Chapters", "Description", "PublishDate", "Publishing", "TitleRomaji", "UpdateDate", "Volumes", "Votes" },
                values: new object[] { 3, "Takeshi Obata", "Tsugumi Ohba", (short)117, "Ryuk, a god of death, drops his Death Note into the human world for personal pleasure. In Japan, prodigious high school student Light Yagami stumbles upon it. Inside the notebook, he finds a chilling message: those whose names are written in it shall die. Its nonsensical nature amuses Light; but when he tests its power by writing the name of a criminal in it, they suddenly meet their demise.\n\nRealizing the Death Note's vast potential, Light commences a series of nefarious murders under the pseudonym \"Kira\", vowing to cleanse the world of corrupt individuals and create a perfect society where crime ceases to exist. However, the police quickly catch on, and they enlist the help of L—a mastermind detective—to uncover the culprit.\n\nDeath Note tells the thrilling tale of Light and L as they clash in a great battle-of-minds, one that will determine the future of the world.", new DateTime(2023, 12, 3, 8, 52, 18, 412, DateTimeKind.Local).AddTicks(8542), "VIZ Media, Shueisha", "Desu Notō", new DateTime(2023, 12, 3, 8, 52, 18, 412, DateTimeKind.Local).AddTicks(8546), (short)12, 47155 });

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_UserID",
                table: "Mangas",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MangaDetails");

            migrationBuilder.DropTable(
                name: "Mangas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

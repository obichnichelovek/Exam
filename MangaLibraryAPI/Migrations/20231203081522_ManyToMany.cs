using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaLibraryAPI.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enum = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tags = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MangaGenre",
                columns: table => new
                {
                    MangaID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaGenre", x => new { x.GenreID, x.MangaID });
                    table.ForeignKey(
                        name: "FK_MangaGenre_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaGenre_Mangas_MangaID",
                        column: x => x.MangaID,
                        principalTable: "Mangas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaTag",
                columns: table => new
                {
                    MangaID = table.Column<int>(type: "int", nullable: false),
                    TagID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaTag", x => new { x.MangaID, x.TagID });
                    table.ForeignKey(
                        name: "FK_MangaTag_Mangas_MangaID",
                        column: x => x.MangaID,
                        principalTable: "Mangas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaTag_Tag_TagID",
                        column: x => x.TagID,
                        principalTable: "Tag",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "ID", "Description", "Enum", "Name" },
                values: new object[,]
                {
                    { 1, "Exciting action sequences take priority and significant conflicts between characters are usually resolved with one's physical power.", (byte)1, "Action" },
                    { 2, "Whether aiming for a specific goal or just struggling to survive, the main character is thrust into unfamiliar situations or lands and continuously faces unexpected dangers.", (byte)2, "Adventure" },
                    { 3, "Uplifting the audience with positive emotion takes priority, eliciting laughter, amusement, or general entertainment.", (byte)3, "Comedy" },
                    { 4, "Self-explanatory name, stories of this genre can be more relaxing and about trying rich and tasty food or be about dynamic, stressful work in the kitchen.", (byte)4, "Cooking" },
                    { 5, "A theme within the Mystery genre, these stories feature either a detective or amateur investigator working to solve a crime or puzzling event.", (byte)5, "Detective" },
                    { 6, "Plot-driven stories focused on realistic characters experiencing human struggle.", (byte)6, "Drama" },
                    { 7, "Magical powers, unnatural creatures, or other unreal elements which cannot be explained by science are prevalent and normal to the setting they exist in.", (byte)7, "Fantasy" },
                    { 8, "Creating—and maintaining—a sense of dread in the audience takes priority, eliciting shock, fear, or disgust through atmosphere and frightening scenarios.", (byte)8, "Horror" },
                    { 9, "Stories about life of Japanese idols.", (byte)9, "Idols" },
                    { 10, "Protagonist getting transferred into another, unknown world.", (byte)10, "Isekai" },
                    { 11, "Piloting giant humanoid robots.", (byte)11, "Mecha" },
                    { 12, "Whether its solving a crime or finding an explanation for a puzzling circumstance, the main cast willingly or reluctantly become investigators who must work to answer the who, what, why, and/or how of the current dilemma.", (byte)12, "Mystery" },
                    { 13, "Survival after end of the world.", (byte)13, "Post-apocalypse" },
                    { 14, "Falling in love and struggling to progress towards—or maintain—a romantic relationship take priority, while other subplots either take backseat or are designed to develop the main love story.", (byte)14, "Romance" },
                    { 15, "Imagined technological advancements or natural settings which are currently unreal in the present day but could be invented, caused, or explained by science in the future.", (byte)15, "Si-Fi" },
                    { 16, "Slice of Life stories are focused on a seemingly random and mundane period of the main characters' lives.", (byte)16, "Slice of Life" },
                    { 17, "Training for and participating in a sport take priority, with the goal of furthering one's athletic abilities—either to win a competition or achieve some social standing.", (byte)17, "Sports" },
                    { 18, "Tough life under constant threat of death.", (byte)18, "Survival" },
                    { 19, "Heroic fantasy. Subgenre of fantasy characterized by sword-wielding heroes engaged in exciting and violent adventures.", (byte)19, "SwordAndSorcery" },
                    { 20, "Characterized and defined by the elicit moods, giving their audiences heightened feelings of suspense, excitement, surprise, anticipation and anxiety.", (byte)20, "Thriller" }
                });

            migrationBuilder.UpdateData(
                table: "MangaDetails",
                keyColumn: "MangaID",
                keyValue: 1,
                columns: new[] { "PublishDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 12, 3, 12, 15, 20, 109, DateTimeKind.Local).AddTicks(9462), new DateTime(2023, 12, 3, 12, 15, 20, 109, DateTimeKind.Local).AddTicks(9488) });

            migrationBuilder.UpdateData(
                table: "MangaDetails",
                keyColumn: "MangaID",
                keyValue: 2,
                columns: new[] { "PublishDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 12, 3, 12, 15, 20, 109, DateTimeKind.Local).AddTicks(9502), new DateTime(2023, 12, 3, 12, 15, 20, 109, DateTimeKind.Local).AddTicks(9510) });

            migrationBuilder.UpdateData(
                table: "MangaDetails",
                keyColumn: "MangaID",
                keyValue: 3,
                columns: new[] { "PublishDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 12, 3, 12, 15, 20, 109, DateTimeKind.Local).AddTicks(9519), new DateTime(2023, 12, 3, 12, 15, 20, 109, DateTimeKind.Local).AddTicks(9528) });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "ID", "Description", "Name", "Tags" },
                values: new object[,]
                {
                    { 1, "Attempt to purify, mature, and perfect certain materials, like the transmutation of \"base metals\" (e.g., lead) into \"noble metals\" (particularly gold).", "Alchemy", (byte)1 },
                    { 2, "Whole or partial loss of memory.", "Amnesia", (byte)2 },
                    { 3, "Usually shaped like humans of extraordinary beauty, often identified with bird wings, halos, and divine light.", "Angels", (byte)3 },
                    { 4, "Anthropomorphs: non-human creatures attributed with human traits and emotions.", "Anthropomorphic", (byte)4 },
                    { 5, "Half-humans & half-animals.", "DemiHuman", (byte)5 },
                    { 6, "Coercion using the threat of revealing compromising information about a person to the public.", "Blackmail", (byte)6 },
                    { 7, "Cold and unforgiving.", "CruelWorld", (byte)7 },
                    { 8, "Dystopian si-fi future that tends to focus on a combination of lowlife and high tech.", "Cyberpunk", (byte)8 },
                    { 9, "Evil beings, minions of the devil, often humanoid, often depicted with horns, bat-like wings, and pointy spear-like tail.", "Demons", (byte)9 },
                    { 10, "Large magical legendary creatures.", "Dragons", (byte)10 },
                    { 11, "Not the smartest.", "DumbProtagonist", (byte)11 },
                    { 12, "Monster filled caves/underground places.", "Dungeon", (byte)12 },
                    { 13, "Distinctive sign of elves are their pointy ears. Commonly shown as creatures with great beauty.", "Elves", (byte)13 },
                    { 14, "Political unit made up of several territories and peoples, usually created by conquest and controlled by the center, the metropole of the empire.", "Empires", (byte)14 },
                    { 15, "Female main character.", "FemaleProtagonist", (byte)15 },
                    { 16, "World in the far future.", "Future", (byte)16 },
                    { 17, "Wagering of money with intent of winning more money, where instances of strategy are discounted.", "Gambling", (byte)17 },
                    { 18, "Soul or spirit of a dead person or another creature that is able to appear to the living.", "Ghosts", (byte)18 },
                    { 19, "All-mighty supernatural creature.", "Gods", (byte)19 }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "ID", "Description", "Name", "Tags" },
                values: new object[,]
                {
                    { 20, "Blood and violence.", "Gore", (byte)20 },
                    { 21, "Japanese subculture, nonconformist or rebelling against Japanese social and aesthetic standards.", "Gyaru", (byte)21 },
                    { 22, "Bunch of women constantly surrounding the protagonist.", "Harem", (byte)22 },
                    { 23, "Total withdrawal from society and seeking extreme degrees of social isolation and confinement.", "Hikikomori", (byte)23 },
                    { 24, "Honorable, noble warrior fully clad in plate armor. Usually armed with sword and shield.", "Knights", (byte)24 },
                    { 25, "Stands for \"lesbian, gay, bisexual, transgender and queer\"", "LGBTQ", (byte)25 },
                    { 26, "Italian criminal organization.", "Mafia", (byte)26 },
                    { 27, "People with ability to use magic.", "Mages", (byte)27 },
                    { 28, "Place where students learn, perfect, or extend their magical powers and knowledge.", "MagicAcademy", (byte)28 },
                    { 29, "Female domestic worker. In manga depicted in style of Victorian era French maids.", "Maids", (byte)29 },
                    { 30, "Male main character.", "MaleProtagonist", (byte)30 },
                    { 31, "Stories in style of European mediæval period.", "Medieval", (byte)31 },
                    { 32, "Life as a soldier.", "Military", (byte)32 },
                    { 33, "Half-girl & half-monster.", "Monstergirls", (byte)33 },
                    { 34, "Often about life in musical band.", "Music", (byte)34 },
                    { 35, "Mythical creatures, monsters.", "Mythology", (byte)35 },
                    { 36, "Japanese assassin.", "Ninja", (byte)36 },
                    { 37, "Parody of common storytelling tropes.", "Parody", (byte)37 },
                    { 38, "Sea bandits.", "Pirates", (byte)38 },
                    { 39, "Power relations among individuals, such as the distribution of resources or status. Sometimes just depiction of political figures.", "Politics", (byte)39 },
                    { 40, "Mind games, mental anguish, etc.", "Psychological", (byte)40 },
                    { 41, "Journey toward a specific mission or a goal.", "Quests", (byte)41 },
                    { 42, "Rebirth in another world after death.", "Reincarnation", (byte)42 },
                    { 43, "Machine programmable by a computer—capable of carrying out a complex series of actions automatically.", "Robots", (byte)43 },
                    { 44, "Military nobility, officer caste of medieval Japan, wearing traditional clothes and wielding katanas.", "Samurais", (byte)44 },
                    { 45, "People being owned and treated like property.", "Slaves", (byte)45 },
                    { 46, "Rare case.", "SmartProtagonist", (byte)46 },
                    { 47, "Retrofuturistic aesthetics inspired by 19th-century industrial steam-powered machinery.", "Steampunk", (byte)47 },
                    { 48, "Primarily taking place on Earth, supernatural stories incorporate elements or attributes that are unnatural and unexplainable by science.", "Supernatural", (byte)48 },
                    { 49, "Living dead, like zombies or skeletons.", "Undead", (byte)49 },
                    { 50, "Blood-suckers.", "Vampires", (byte)50 },
                    { 51, "Story driven around protagonist's desire for retribution.", "Vengeance", (byte)51 },
                    { 52, "Electronic games.", "Videogames", (byte)52 },
                    { 53, "Reality but virtual.", "VirtualReality", (byte)53 },
                    { 54, "Practitioner of witchcraft: magic used to inflict harm or misfortune on others.", "Witch", (byte)54 },
                    { 55, "Japanese mafioso.", "Yakudza", (byte)55 },
                    { 56, "Initially loving and caring until their romantic love, admiration and devotion becomes feisty and mentally destructive in nature through either overprotectiveness, violence, brutality or all three combined.", "Yandere", (byte)56 },
                    { 57, "Green, undead brain-lover.", "Zombie", (byte)57 }
                });

            migrationBuilder.InsertData(
                table: "MangaGenre",
                columns: new[] { "GenreID", "MangaID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 5, 3 },
                    { 6, 2 },
                    { 6, 3 },
                    { 7, 1 },
                    { 7, 2 },
                    { 8, 1 },
                    { 19, 1 },
                    { 20, 3 }
                });

            migrationBuilder.InsertData(
                table: "MangaTag",
                columns: new[] { "MangaID", "TagID" },
                values: new object[,]
                {
                    { 1, 7 },
                    { 1, 9 },
                    { 1, 20 },
                    { 1, 30 },
                    { 1, 31 },
                    { 1, 40 },
                    { 1, 48 },
                    { 1, 51 },
                    { 2, 35 },
                    { 2, 50 },
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 19 },
                    { 3, 30 },
                    { 3, 35 },
                    { 3, 40 },
                    { 3, 48 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MangaGenre_MangaID",
                table: "MangaGenre",
                column: "MangaID");

            migrationBuilder.CreateIndex(
                name: "IX_MangaTag_TagID",
                table: "MangaTag",
                column: "TagID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MangaGenre");

            migrationBuilder.DropTable(
                name: "MangaTag");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.UpdateData(
                table: "MangaDetails",
                keyColumn: "MangaID",
                keyValue: 1,
                columns: new[] { "PublishDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 12, 3, 8, 52, 18, 412, DateTimeKind.Local).AddTicks(8493), new DateTime(2023, 12, 3, 8, 52, 18, 412, DateTimeKind.Local).AddTicks(8515) });

            migrationBuilder.UpdateData(
                table: "MangaDetails",
                keyColumn: "MangaID",
                keyValue: 2,
                columns: new[] { "PublishDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 12, 3, 8, 52, 18, 412, DateTimeKind.Local).AddTicks(8524), new DateTime(2023, 12, 3, 8, 52, 18, 412, DateTimeKind.Local).AddTicks(8533) });

            migrationBuilder.UpdateData(
                table: "MangaDetails",
                keyColumn: "MangaID",
                keyValue: 3,
                columns: new[] { "PublishDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 12, 3, 8, 52, 18, 412, DateTimeKind.Local).AddTicks(8542), new DateTime(2023, 12, 3, 8, 52, 18, 412, DateTimeKind.Local).AddTicks(8546) });
        }
    }
}

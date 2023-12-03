using MangaLibraryAPI.Entities;
using MangaLibraryAPI.Entities.MtMRO;
using MangaLibraryAPI.Enumerators;
using static MangaLibraryAPI.Enumerators.Genres;
using static MangaLibraryAPI.Enumerators.Tags;
using Microsoft.EntityFrameworkCore;

namespace MangaLibraryAPI.DatabaseContexts;

public sealed class MangaLibraryContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Manga> Mangas { get; set; } = null!;
    public DbSet<MangaDetails> MangaDetails { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region GENRES-MANGA
        modelBuilder.Entity<Manga>(x =>
        {
            x.HasMany(y => y.Genres)
            .WithMany(z => z.Mangas)
            .UsingEntity<MangaGenre>(
                genre => genre
                    .HasOne(x => x.Genre)
                    .WithMany(y => y.MangaGenres)
                    .HasForeignKey(z => z.GenreID),

                manga => manga
                    .HasOne(x => x.Manga)
                    .WithMany(y => y.MangaGenres)
                    .HasForeignKey(z => z.MangaID));
        });
        #endregion

        #region TAG-MANGA
        modelBuilder.Entity<Manga>(x =>
        {
            x.HasMany(y => y.Tags)
            .WithMany(z => z.Mangas)
            .UsingEntity<MangaTag>(
                tag => tag
                    .HasOne(x => x.Tag)
                    .WithMany(y => y.MangaTags)
                    .HasForeignKey(z => z.TagID),

                manga => manga
                    .HasOne(x => x.Manga)
                    .WithMany(y => y.MangaTags)
                    .HasForeignKey(z => z.MangaID));
        });
        #endregion

        #region GENRES
        modelBuilder.Entity<Genre>().HasData(
            new Genre(Genres.Action),
            new Genre(Adventure),
            new Genre(Comedy),
            new Genre(Cooking),
            new Genre(Detective),
            new Genre(Drama),
            new Genre(Fantasy),
            new Genre(Horror),
            new Genre(Idols),
            new Genre(Isekai),
            new Genre(Mecha),
            new Genre(Mystery),
            new Genre(PostApocalypse),
            new Genre(Romance),
            new Genre(SiFi),
            new Genre(SliceOfLife),
            new Genre(Sports),
            new Genre(Survival),
            new Genre(SwordAndSorcery),
            new Genre(Thriller));
        #endregion

        #region TAGS
        modelBuilder.Entity<Tag>().HasData(
            new Tag(Alchemy),
            new Tag(Amnesia),
            new Tag(Angels),
            new Tag(Anthropomorphic),
            new Tag(DemiHuman),
            new Tag(Blackmail),
            new Tag(CruelWorld),
            new Tag(Cyberpunk),
            new Tag(Demons),
            new Tag(Dragons),
            new Tag(DumbProtagonist),
            new Tag(Dungeon),
            new Tag(Elves),
            new Tag(Empires),
            new Tag(FemaleProtagonist),
            new Tag(Future),
            new Tag(Gambling),
            new Tag(Ghosts),
            new Tag(Gods),
            new Tag(Gore),
            new Tag(Gyaru),
            new Tag(Harem),
            new Tag(Hikikomori),
            new Tag(Knights),
            new Tag(LGBTQ),
            new Tag(Mafia),
            new Tag(Mages),
            new Tag(MagicAcademy),
            new Tag(Maids),
            new Tag(MaleProtagonist),
            new Tag(Medieval),
            new Tag(Military),
            new Tag(Monstergirls),
            new Tag(Music),
            new Tag(Mythology),
            new Tag(Ninja),
            new Tag(Parody),
            new Tag(Pirates),
            new Tag(Politics),
            new Tag(Psychological),
            new Tag(Quests),
            new Tag(Reincarnation),
            new Tag(Robots),
            new Tag(Samurais),
            new Tag(Slaves),
            new Tag(SmartProtagonist),
            new Tag(Steampunk),
            new Tag(Supernatural),
            new Tag(Undead),
            new Tag(Vampires),
            new Tag(Vengeance),
            new Tag(Videogames),
            new Tag(VirtualReality),
            new Tag(Witch),
            new Tag(Yakudza),
            new Tag(Yandere),
            new Tag(Zombie));
        #endregion

        modelBuilder.Entity<User>().HasData(
            new User
            {
                ID = 1,
                Name = "Admin",
                Email = "obichnichelovek@vk.com",
                Password = "SuperSecretPassword",
                Role = Roles.Administrator
            },
            new User
            {
                ID = 2,
                Name = "User123",
                Email = "sample@email.com",
                Password = "321",
                Role = Roles.Standard
            });

        modelBuilder.Entity<Manga>(x =>
        {
            x.HasData(
                new
                {
                    ID = 1,
                    TitleEnglish = "Berserk",
                    TitleJapanese = "ベルセルク",
                    ShortDescription = "Guts, a former mercenary now known as the \"Black Swordsman\", is out for revenge. After a tumultuous childhood, he finally finds someone he respects and believes he can trust, only to have everything fall apart when this person takes away everything...",
                    Status = Status.Ongoing,
                    Bookmark = Bookmark.None,
                    Rating = 9.84f,
                    Poster = "https://cdn.myanimelist.net/images/manga/1/157897.jpg",
                    ReleaseYear = (short)1989
                },
                new
                {
                    ID = 2,
                    TitleEnglish = "Castlevania: Curse of Darkness",
                    TitleJapanese = "悪魔城ドラキュラ 闇の呪印",
                    ShortDescription = "\"Akumajō Dracula: Yami no Juin\" had in Japan its own comic series that lasted all of two volumes. The comic series of the same name was created in 2005 by company Mediafactory, and it follows events that overlap with bonus-material comic...",
                    Status = Status.Finished,
                    Bookmark = Bookmark.None,
                    Rating = 9.36f,
                    Poster = "https://cdn.myanimelist.net/images/manga/3/265854.jpg",
                    ReleaseYear = (short)2005,

                },
                new
                {
                    ID = 3,
                    TitleEnglish = "Death Note",
                    TitleJapanese = "デスノート",
                    ShortDescription = "Ryuk, a god of death, drops his Death Note into the human world for personal pleasure. In Japan, prodigious high school student Light Yagami stumbles upon it. Inside the notebook, he finds a chilling message: those whose names are written in it shall die.",
                    Status = Status.Finished,
                    Bookmark = Bookmark.None,
                    Rating = 9.6f,
                    Poster = "https://cover.imglib.info/uploads/cover/desu-noto/cover/5UcB013CNhll_250x350.jpg",
                    ReleaseYear = (short)2003
                });

            x.OwnsOne(y => y.Details).HasKey(x => x.MangaID);
            x.OwnsOne(y => y.Details).HasOne(x => x.Manga);

            x.OwnsOne(y => y.Details).HasData(
                new 
                {
                    MangaID = 1,

                    TitleRomaji = "Beruseruku",
                    Description = "Guts, a former mercenary now known as the \"Black Swordsman\", is out for revenge. After a tumultuous childhood, he finally finds someone he respects and believes he can trust, only to have everything fall apart when this person takes away everything important to Guts for the purpose of fulfilling his own desires. Now marked for death, Guts becomes condemned to a fate in which he is relentlessly pursued by demonic beings.\n\nSetting out on a dreadful quest riddled with misfortune, Guts, armed with a massive sword and monstrous strength, will let nothing stop him, not even death itself, until he is finally able to take the head of the one who stripped him—and his loved one—of their humanity.",
                    Author = "Kentaro Miura",
                    Artist = "Kentaro Miura",
                    Publishing = "Hakusensha, Dark Horse Comics, XL Media",

                    Votes = 12646,
                    Volumes = (short)41,
                    Chapters = (short)376,

                    PublishDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                },
                new 
                {
                    MangaID = 2,

                    TitleRomaji = "Akumajō Dracula: Yami no Juin",
                    Description = "\"Akumajō Dracula: Yami no Juin\" had in Japan its own comic series that lasted all of two volumes. The comic series of the same name was created in 2005 by company Mediafactory, and it follows events that overlap with bonus-material comic Prelude of Revenge, whose story was conceived by Ayami Kojima; the series is, according to her, a true extension of the of both Prelude and therein the game's actual story. Adding to its authenticity is the knowledge that Koji Igarashi completely supervised its creation.",
                    Author = "SASAKURA Kou",
                    Artist = "SASAKURA Kou",
                    Publishing = "Media Factory",

                    Votes = 42,
                    Volumes = (short)2,
                    Chapters = (short)4,

                    PublishDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                },
                new 
                {
                    MangaID = 3,

                    TitleRomaji = "Desu Notō",
                    Description = "Ryuk, a god of death, drops his Death Note into the human world for personal pleasure. In Japan, prodigious high school student Light Yagami stumbles upon it. Inside the notebook, he finds a chilling message: those whose names are written in it shall die. Its nonsensical nature amuses Light; but when he tests its power by writing the name of a criminal in it, they suddenly meet their demise.\n\nRealizing the Death Note's vast potential, Light commences a series of nefarious murders under the pseudonym \"Kira\", vowing to cleanse the world of corrupt individuals and create a perfect society where crime ceases to exist. However, the police quickly catch on, and they enlist the help of L—a mastermind detective—to uncover the culprit.\n\nDeath Note tells the thrilling tale of Light and L as they clash in a great battle-of-minds, one that will determine the future of the world.",
                    Author = "Tsugumi Ohba",
                    Artist = "Takeshi Obata",
                    Publishing = "VIZ Media, Shueisha",

                    Votes = 47155,
                    Volumes = (short)12,
                    Chapters = (short)117,

                    PublishDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                });
        });

        #region MANGA-GENRE

        modelBuilder.Entity<MangaGenre>(x =>
        {
            x.HasData(
                //Berserk
                new() { MangaID = 1, GenreID = (int)Genres.Action },
                new() { MangaID = 1, GenreID = (int)Horror },
                new() { MangaID = 1, GenreID = (int)Adventure },
                new() { MangaID = 1, GenreID = (int)Fantasy },
                new() { MangaID = 1, GenreID = (int)SwordAndSorcery },

                //Castlevania
                new() { MangaID = 2, GenreID = (int)Genres.Action },
                new() { MangaID = 2, GenreID = (int)Drama },
                new() { MangaID = 2, GenreID = (int)Fantasy },

                //Death Note
                new() { MangaID = 3, GenreID = (int)Genres.Action },
                new() { MangaID = 3, GenreID = (int)Drama },
                new() { MangaID = 3, GenreID = (int)Detective },
                new() { MangaID = 3, GenreID = (int)Thriller }
                );
        });

        #endregion

        #region MANGA-TAG

        modelBuilder.Entity<MangaTag>(x =>
        {
            x.HasData(
                //Berserk
                new() { MangaID = 1, TagID = (int)Demons },
                new() { MangaID = 1, TagID = (int)Gore },
                new() { MangaID = 1, TagID = (int)CruelWorld },
                new() { MangaID = 1, TagID = (int)Vengeance },
                new() { MangaID = 1, TagID = (int)Medieval },
                new() { MangaID = 1, TagID = (int)Psychological },
                new() { MangaID = 1, TagID = (int)MaleProtagonist },
                new() { MangaID = 1, TagID = (int)Supernatural },

                //Castlevania
                new() { MangaID = 2, TagID = (int)Mythology },
                new() { MangaID = 2, TagID = (int)Vampires },

                //Death Note
                new() { MangaID = 3, TagID = (int)Psychological },
                new() { MangaID = 3, TagID = (int)Mythology },
                new() { MangaID = 3, TagID = (int)Supernatural },
                new() { MangaID = 3, TagID = (int)Gods },
                new() { MangaID = 3, TagID = (int)CruelWorld },
                new() { MangaID = 3, TagID = (int)MaleProtagonist },
                new() { MangaID = 3, TagID = (int)Blackmail }
                );
        });

        #endregion

        base.OnModelCreating(modelBuilder);
    }

    public MangaLibraryContext(DbContextOptions options) : base(options)
    {
        
    }
}

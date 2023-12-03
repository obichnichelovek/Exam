using MangaLibraryAPI.Attributes;
using MangaLibraryAPI.Enumerators;
using System.Text;

namespace MangaLibraryAPI.Services;

public sealed class Tools
{
    public static string GetEnumDescription(Tags tag)
    {
        var fieldInfo = tag.GetType().GetField(GetEnumName(tag));
        var attributes = fieldInfo!.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        return attributes![0].Description;
    }

    public static string GetEnumDescription(Genres genre)
    {
        var fieldInfo = genre.GetType().GetField(GetEnumName(genre));
        var attributes = fieldInfo!.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        return attributes![0].Description;
    }

    public static string? GetCustomName(Genres genre)
    {
        var fieldInfo = genre.GetType().GetField(GetEnumName(genre));
        var attributes = fieldInfo!.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        return attributes![0].Name;
    }

    public static string FixCase(string name)
    {
        for (byte i = 0, j = 1; i < name.Length - 1; i++, j++)
            if (char.IsUpper(name[j])) name = name.PadLeft(i);
        return name;
    }

    public static Roles GetRole(string str)
    {
        return str switch
        {
            "Standard" => Roles.Standard,
            "Administrator" => Roles.Administrator,
            _ => throw new ArgumentOutOfRangeException(nameof(str), str, null)
        };
    }

    public static string GetRoleName(Roles role)
    {
        return role switch
        {
            Roles.Standard => nameof(Roles.Standard),
            Roles.Administrator => nameof(Roles.Administrator),
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
        };
    }

    public static string GetEnumName(Tags tag)
    {
        #region Tags
        switch (tag)
        {
            case Tags.Alchemy: return nameof(Tags.Alchemy);
            case Tags.Amnesia: return nameof(Tags.Amnesia);
            case Tags.Angels: return nameof(Tags.Angels);
            case Tags.Anthropomorphic: return nameof(Tags.Anthropomorphic);
            case Tags.DemiHuman: return nameof(Tags.DemiHuman);
            case Tags.Blackmail: return nameof(Tags.Blackmail);
            case Tags.CruelWorld: return nameof(Tags.CruelWorld);
            case Tags.Cyberpunk: return nameof(Tags.Cyberpunk);
            case Tags.Demons: return nameof(Tags.Demons);
            case Tags.Dragons: return nameof(Tags.Dragons);
            case Tags.DumbProtagonist: return nameof(Tags.DumbProtagonist);
            case Tags.Dungeon: return nameof(Tags.Dungeon);
            case Tags.Elves: return nameof(Tags.Elves);
            case Tags.Empires: return nameof(Tags.Empires);
            case Tags.FemaleProtagonist: return nameof(Tags.FemaleProtagonist);
            case Tags.Future: return nameof(Tags.Future);
            case Tags.Gambling: return nameof(Tags.Gambling);
            case Tags.Ghosts: return nameof(Tags.Ghosts);
            case Tags.Gods: return nameof(Tags.Gods);
            case Tags.Gore: return nameof(Tags.Gore);
            case Tags.Gyaru: return nameof(Tags.Gyaru);
            case Tags.Harem: return nameof(Tags.Harem);
            case Tags.Hikikomori: return nameof(Tags.Hikikomori);
            case Tags.Knights: return nameof(Tags.Knights);
            case Tags.LGBTQ: return nameof(Tags.LGBTQ);
            case Tags.Mafia: return nameof(Tags.Mafia);
            case Tags.Mages: return nameof(Tags.Mages);
            case Tags.MagicAcademy: return nameof(Tags.MagicAcademy);
            case Tags.Maids: return nameof(Tags.Maids);
            case Tags.MaleProtagonist: return nameof(Tags.MaleProtagonist);
            case Tags.Medieval: return nameof(Tags.Medieval);
            case Tags.Military: return nameof(Tags.Military);
            case Tags.Monstergirls: return nameof(Tags.Monstergirls);
            case Tags.Music: return nameof(Tags.Music);
            case Tags.Mythology: return nameof(Tags.Mythology);
            case Tags.Ninja: return nameof(Tags.Ninja);
            case Tags.Parody: return nameof(Tags.Parody);
            case Tags.Pirates: return nameof(Tags.Pirates);
            case Tags.Politics: return nameof(Tags.Politics);
            case Tags.Psychological: return nameof(Tags.Psychological);
            case Tags.Quests: return nameof(Tags.Quests);
            case Tags.Reincarnation: return nameof(Tags.Reincarnation);
            case Tags.Robots: return nameof(Tags.Robots);
            case Tags.Samurais: return nameof(Tags.Samurais);
            case Tags.Slaves: return nameof(Tags.Slaves);
            case Tags.SmartProtagonist: return nameof(Tags.SmartProtagonist);
            case Tags.Steampunk: return nameof(Tags.Steampunk);
            case Tags.Supernatural: return nameof(Tags.Supernatural);
            case Tags.Undead: return nameof(Tags.Undead);
            case Tags.Vampires: return nameof(Tags.Vampires);
            case Tags.Vengeance: return nameof(Tags.Vengeance);
            case Tags.Videogames: return nameof(Tags.Videogames);
            case Tags.VirtualReality: return nameof(Tags.VirtualReality);
            case Tags.Witch: return nameof(Tags.Witch);
            case Tags.Yakudza: return nameof(Tags.Yakudza);
            case Tags.Yandere: return nameof(Tags.Yandere);
            case Tags.Zombie: return nameof(Tags.Zombie);

            default:
                throw new ArgumentOutOfRangeException(nameof(tag), tag, null);
        }
        #endregion
    }

    public static string GetEnumName(Genres genre)
    {
        #region Genres

        switch (genre)
        {
            case Genres.Action: return nameof(Genres.Action);
            case Genres.Adventure: return nameof(Genres.Adventure);
            case Genres.Comedy: return nameof(Genres.Comedy);
            case Genres.Cooking: return nameof(Genres.Cooking);
            case Genres.Detective: return nameof(Genres.Detective);
            case Genres.Drama: return nameof(Genres.Drama);
            case Genres.Fantasy: return nameof(Genres.Fantasy);
            case Genres.Horror: return nameof(Genres.Horror);
            case Genres.Idols: return nameof(Genres.Idols);
            case Genres.Isekai: return nameof(Genres.Isekai);
            case Genres.Mecha: return nameof(Genres.Mecha);
            case Genres.Mystery: return nameof(Genres.Mystery);
            case Genres.PostApocalypse: return nameof(Genres.PostApocalypse);
            case Genres.Romance: return nameof(Genres.Romance);
            case Genres.SiFi: return nameof(Genres.SiFi);
            case Genres.SliceOfLife: return nameof(Genres.SliceOfLife);
            case Genres.Sports: return nameof(Genres.Sports);
            case Genres.Survival: return nameof(Genres.Survival);
            case Genres.SwordAndSorcery: return nameof(Genres.SwordAndSorcery);
            case Genres.Thriller: return nameof(Genres.Thriller);

            default:
                throw new ArgumentOutOfRangeException(nameof(genre), genre, null);
        }

        #endregion
    }
}

using meta_data_api.Models;
using TNA.DataDefinitionObjects;

namespace meta_data_api;

public static class Mapping
{
    public static TEnum ToEnum<TEnum>(this string value, TEnum defaultValue = default)
    where TEnum : struct, Enum
    {
        return Enum.TryParse(value, true, out TEnum result) ? result : defaultValue;
    }
    public static DFile ToDFile(this DigitalFileModel src)
    {
        if (src == null) return null;

        return new DFile
        {
            CSum = src.CheckSum,
            Frmt = src.Format,
            OrigName = src.OriginalName,
            Size = src.Size,
            Name = src.Name
        };
    }

    public static DigitalFileModel ToDigitalFileModel(this DFile src)
    {
        if (src == null) return null;

        return new DigitalFileModel
        {
            CheckSum = src.CSum,
            Format = src.Frmt,
            OriginalName = src.OrigName,
            Size = src.Size,
            Name = src.Name
        };
    }

    public static Repl ToRepl(this ReplicaModel src)
    {
        if (src == null) return null;

        return new Repl
        {
            RID = src.ReplicaId,
            Orig = src.Origination.ToEnum<Origination>(Origination.Digitised),
            TSize = src.TotalSize,
            Files = src.Files.Select(x => x.ToDFile()).ToList()
        };
    }

    public static ReplicaModel ToReplicaModel(this Repl src)
    {
        if (src == null) return null;

        return new ReplicaModel
        {
            ReplicaId = src.RID,
            Origination = src.Orig.ToString(),
            TotalSize = src.TSize,
            Files = src.Files.Select(x => x.ToDigitalFileModel()).ToList()
        };
    }

    public static FileEditSet ToFileEditSet(this FileEditSetModel src)
    {
        if (src == null) return null;

        return new FileEditSet
        {
            Init = src.Initial,
            Curt = src.Current,
            Frmt = src.Format,
            OrigName = src.OriginalName,
            Action = (TNA.DataDefinitionObjects.Action)src.Action,
            Name = src.Name,
            Size = src.Size
        };
    }

    public static FileEditSetModel ToFileEditSetModel(this FileEditSet src)
    {
        if (src == null) return null;

        return new FileEditSetModel
        {
            Initial = src.Init,
            Current = src.Curt,
            Format = src.Frmt,
            OriginalName = src.OrigName,
            Name = src.Name,
            Action = (int)src.Action,
            Size = src.Size
        };
    }

    public static ReplEditSet ToReplEditSet(this ReplicaEditSetModel src)
    {
        if (src == null) return null;

        return new ReplEditSet
        {
            Usr = src.User,
            Req = src.Requested,
            Sub = src.Submitted,
            IAID = src.IAID,
            RID = src.RID,
            Files = src.Files.Select(x => x.ToFileEditSet()).ToList()
        };
    }

    public static ReplicaEditSetModel ToReplicaEditSetModel(this ReplEditSet src)
    {
        if (src == null) return null;

        return new ReplicaEditSetModel
        {
            User = src.Usr,
            Requested = src.Req,
            Submitted = src.Sub,
            IAID = src.IAID,
            RID = src.RID,
            Files = src.Files.Select(x => x.ToFileEditSetModel()).ToList()
        };
    }

    public static PreparedFileItem ToPreparedFileItem(this PreparedFileItemModel src)
    {
        if (src == null) return null;

        return new PreparedFileItem
        {
            FileName = src.FileName,
            FromImage = src.FromImage,
            ToImage = src.ToImage,
            ContentType = src.ContentType
        };
    }

    public static PreparedFileItemModel ToPreparedFileItemModel(this PreparedFileItem src)
    {
        if (src == null) return null;

        return new PreparedFileItemModel
        {
            FileName = src.FileName,
            FromImage = src.FromImage,
            ToImage = src.ToImage,
            ContentType = src.ContentType
        };
    }

    public static PrepFile ToPrepFile(this PreparedFileModel src)
    {
        if (src == null) return null;

        return new PrepFile
        {
            IAID = src.IAID,
            Count = src.Count,
            PercentCompleted = src.PercentCompleted,
            LastDownloadTimestamp = src.LastDownloadTimestamp,
            LastDownloadTimestampPretty = src.LastDownloadTimestampPretty,
            Parts = src.Parts.Select(x => x.ToPreparedFileItem()).ToList()
        };
    }

    public static PreparedFileModel ToPreparedFileModel(this PrepFile src)
    {
        if (src == null) return null;

        return new PreparedFileModel
        {
            IAID = src.IAID,
            Count = src.Count,
            PercentCompleted = src.PercentCompleted,
            LastDownloadTimestamp = src.LastDownloadTimestamp,
            LastDownloadTimestampPretty = src.LastDownloadTimestampPretty,
            Parts = src.Parts.Select(x => x.ToPreparedFileItemModel()).ToList()
        };
    }
}
﻿using System.IO;
using System.Linq;
using SharpCompress.Common.Zip;

namespace SharpCompress.Archives.Zip;

public class ZipArchiveEntry : ZipEntry, IArchiveEntry
{
    internal ZipArchiveEntry(ZipArchive archive, SeekableZipFilePart? part)
        : base(part) => Archive = archive;

    public virtual Stream OpenEntryStream() => Parts.Single().GetCompressedStream().NotNull();

    #region IArchiveEntry Members

    public IArchive Archive { get; }

    public bool IsComplete => true;

    #endregion
}

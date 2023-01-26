using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace ConsoleUtilitiesLibary
{
    /// <summary>
    /// A class for printing Folders and Files to the Console
    /// </summary>
    public static class ConsoleIO
    {
        private static readonly IOColums[] DefaultColums = { IOColums.Name, IOColums.Extension, IOColums.Size };

        /// <summary>
        /// Print The Folders Contetns
        /// </summary>
        /// <param name="line">The console line to start printing at</param>
        /// <param name="path">The Folder Path</param>
        public static void PrintFolder (int line, string path)
        {
            if (!Directory.Exists(path))
            {
                ConsoleUtilities.ReplaceLine(line, $"Path \"{path}\" does not Exist...");
                return;
            }

            PrintFolder(line, new DirectoryInfo(path));
        }

        /// <summary>
        /// Print The Folders Contetns
        /// </summary>
        /// <param name="line">The console line to start printing at</param>
        /// <param name="dir"></param>
        public static void PrintFolder (int line, DirectoryInfo dir)
        {
            ConsoleUtilities.ReplaceLine(line, $"Showing content of Directory \"{dir.FullName}\"");
            ConsoleTables.PrintTable(line + 1, Conversions.DataTableSizeFormat(Conversions.DirectoryAsTable(dir)), TableLook.DoubleLines, true);
        }

        /// <summary>
        /// Print The Folders Contetns
        /// </summary>
        /// <param name="line">The console line to start printing at</param>
        /// <param name="path">Folder Path</param>
        /// <param name="sort">What colum is sortet after</param>
        public static void PrintFolder (int line, string path, IOSorting sort)
        {
            if (!Directory.Exists(path))
            {
                ConsoleUtilities.ReplaceLine(line, $"Path \"{path}\" does not Exist...");
                return;
            }

            PrintFolder(line, new DirectoryInfo(path), sort);
        }

        /// <summary>
        /// Print The Folders Contetns
        /// </summary>
        /// <param name="line">The console line to start printing at</param>
        /// <param name="dir">The FolderInfo</param>
        /// <param name="sort">What colum is sortet after</param>
        public static void PrintFolder (int line, DirectoryInfo dir, IOSorting sort)
        {
            ConsoleUtilities.ReplaceLine(line, $"Showing content of Directory \"{dir.FullName}\"");
            DataTable table = Conversions.DirectoryAsTable(dir);
            if (Conversions.ValidateSorting(sort, DefaultColums))
            {
                table.DefaultView.Sort = Conversions.GetSortKey(sort);
                ConsoleTables.PrintTable(line + 1, Conversions.DataTableSizeFormat(table.DefaultView.ToTable()), TableLook.DoubleLines, true);
            }
            else
            {
                ConsoleTables.PrintTable(line + 1, Conversions.DataTableSizeFormat(table), TableLook.DoubleLines, true);
            }
        }

        /// <summary>
        /// Print The Folders Contetns
        /// </summary>
        /// <param name="line">The console line to start printing at</param>
        /// <param name="path">The Folder Path</param>
        /// <param name="sort">What colum is sortet after</param>
        /// <param name="look">How the printet List looks</param>
        public static void PrintFolder (int line, string path, IOSorting sort, TableLook look)
        {
            if (!Directory.Exists(path))
            {
                ConsoleUtilities.ReplaceLine(line, $"Path \"{path}\" does not Exist...");
                return;
            }

            PrintFolder(line, new DirectoryInfo(path), sort, look);
        }

        /// <summary>
        /// Print The Folders Contetns
        /// </summary>
        /// <param name="line">The console line to start printing at</param>
        /// <param name="dir">The FolderInfo</param>
        /// <param name="sort">What colum is sortet after</param>
        /// <param name="look">How the printet List looks</param>
        public static void PrintFolder (int line, DirectoryInfo dir, IOSorting sort, TableLook look)
        {
            ConsoleUtilities.ReplaceLine(line, $"Showing content of Directory \"{dir.FullName}\"");
            DataTable table = Conversions.DirectoryAsTable(dir);
            if (Conversions.ValidateSorting(sort, DefaultColums))
            {
                table.DefaultView.Sort = Conversions.GetSortKey(sort);
                ConsoleTables.PrintTable(line + 1, Conversions.DataTableSizeFormat(table.DefaultView.ToTable()), look, true);
            }
            else
            {
                ConsoleTables.PrintTable(line + 1, Conversions.DataTableSizeFormat(table), look, true);
            }
        }

        /// <summary>
        /// Print The Folders Contetns
        /// </summary>
        /// <param name="line">The console line to start printing at</param>
        /// <param name="dir">The FolderInfo</param>
        /// <param name="sort">What colum is sortet after</param>
        /// <param name="look">How the printet List looks</param>
        /// <param name="colums">What IOColums are countained in the list</param>
        public static void PrintFolder (int line, DirectoryInfo dir, IOSorting sort, TableLook look, IOColums[] colums)
        {
            ConsoleUtilities.ReplaceLine(line, $"Showing content of Directory \"{dir.FullName}\"");
            DataTable table = Conversions.DirectoryAsTable(dir, colums);
            if (Conversions.ValidateSorting(sort, colums))
            {
                table.DefaultView.Sort = Conversions.GetSortKey(sort);
                ConsoleTables.PrintTable(line + 1, Conversions.DataTableSizeFormat(table.DefaultView.ToTable()), look, true);
            }
            else
            {
                ConsoleTables.PrintTable(line + 1, Conversions.DataTableSizeFormat(table), look, true);
            }
        }

        /// <summary>
        /// Print The Folders Contetns
        /// </summary>
        /// <param name="line">The console line to start printing at</param>
        /// <param name="path">The Folder Path</param>
        /// <param name="sort">What colum is sortet after</param>
        /// <param name="look">How the printet List looks</param>
        /// <param name="colums">What IOColums are countained in the list</param>
        public static void PrintFolder (int line, string path, IOSorting sort, TableLook look, IOColums[] colums)
        {
            if (!Directory.Exists(path))
            {
                ConsoleUtilities.ReplaceLine(line, $"Path \"{path}\" does not Exist...");
                return;
            }

            PrintFolder(line, new DirectoryInfo(path), sort, look, colums);
        }

        /// <summary>
        /// Print The Folders Contetns
        /// </summary>
        /// <param name="line">The console line to start printing at</param>
        /// <param name="path">The Folder Path</param>
        /// <param name="sort">What colum is sortet after</param>
        /// <param name="colums">What IOColums are countained in the list</param>
        public static void PrintFolder (int line, string path, IOSorting sort, IOColums[] colums)
        {
            PrintFolder(line, path, sort, TableLook.DoubleLines, colums);
        }

        /// <summary>
        /// Print The Folders Contetns
        /// </summary>
        /// <param name="line">The console line to start printing at</param>
        /// <param name="dir">The FolderInfo</param>
        /// <param name="sort">What colum is sortet after</param>
        /// <param name="colums">What IOColums are countained in the list</param>
        public static void PrintFolder (int line, DirectoryInfo dir, IOSorting sort, IOColums[] colums)
        {
            PrintFolder(line, dir, sort, TableLook.DoubleLines, colums);
        }

        /// <summary>
        /// Print The Folders Contetns
        /// </summary>
        /// <param name="line">The console line to start printing at</param>
        /// <param name="path">The Folder Path</param>
        /// <param name="colums">What IOColums are countained in the list</param>
        public static void PrintFolder (int line, string path, IOColums[] colums)
        {
            PrintFolder(line, path, IOSorting.NoSorting, TableLook.DoubleLines, colums);
        }

        /// <summary>
        /// Print The Folders Contetns
        /// </summary>
        /// <param name="line">The console line to start printing at</param>
        /// <param name="dir">The directory to print</param>
        /// <param name="colums">What IOColums are countained in the list</param>
        public static void PrintFolder (int line, DirectoryInfo dir, IOColums[] colums)
        {
            PrintFolder(line, dir, IOSorting.NoSorting, TableLook.DoubleLines, colums);
        }

        /// <summary>
        /// Print The Folders Contetns
        /// </summary>
        /// <param name="line">The console line to start printing at</param>
        /// <param name="path">The Folder Path</param>
        /// <param name="look">How the printet List looks</param>
        /// <param name="colums">What IOColums are countained in the list</param>
        public static void PrintFolder (int line, string path, TableLook look, IOColums[] colums)
        {
            PrintFolder(line, path, IOSorting.NoSorting, look, colums);
        }

        /// <summary>
        /// Print The Folders Contetns
        /// </summary>
        /// <param name="line">The console line to start printing at</param>
        /// <param name="dir">The FolderInfi</param>
        /// <param name="look">How the printet List looks</param>
        /// <param name="colums">What IOColums are countained in the list</param>
        public static void PrintFolder (int line, DirectoryInfo dir, TableLook look, IOColums[] colums)
        {
            PrintFolder(line, dir, IOSorting.NoSorting, look, colums);
        }

        /// <summary>
        /// Print details about a file in a list form <see cref="ConsoleLists"/>
        /// </summary>
        /// <param name="line">the line to start printing at</param>
        /// <param name="path">file path</param>
        public static void PrintFile (int line, string path)
        {
            PrintFile(line, new FileInfo(path), new FileCategorys[] { FileCategorys.Name, FileCategorys.Extension, FileCategorys.Size, FileCategorys.FullPath }, TableLook.Default);
        }

        /// <summary>
        /// Print details about a file in a list form <see cref="ConsoleLists"/>
        /// </summary>
        /// <param name="line">the line to start printing at</param>
        /// <param name="path">file path</param>
        /// <param name="categorys">categorys that detirmin what is in the list and in what order</param>
        public static void PrintFile (int line, string path, FileCategorys[] categorys)
        {
            PrintFile(line, new FileInfo(path), categorys, TableLook.Default);
        }

        /// <summary>
        /// Print details about a file in a list form <see cref="ConsoleLists"/>
        /// </summary>
        /// <param name="line">the line to start printing at</param>
        /// <param name="path">file path</param>
        /// <param name="style">how the list looks</param>
        public static void PrintFile (int line, string path, TableLook style)
        {
            PrintFile(line, new FileInfo(path), new FileCategorys[] {FileCategorys.Name, FileCategorys.Extension, FileCategorys.Size, FileCategorys.FullPath}, style);
        }

        /// <summary>
        /// Print details about a file in a list form <see cref="ConsoleLists"/>
        /// </summary>
        /// <param name="line">the line to start printing at</param>
        /// <param name="file">FileInfo</param>
        public static void PrintFile (int line, FileInfo file)
        {
            PrintFile(line, file, new FileCategorys[] { FileCategorys.Name, FileCategorys.Extension, FileCategorys.Size, FileCategorys.FullPath }, TableLook.Default);
        }

        /// <summary>
        /// Print details about a file in a list form <see cref="ConsoleLists"/>
        /// </summary>
        /// <param name="line">the line to start printing at</param>
        /// <param name="file">FileInfo</param>
        /// <param name="categorys">categorys that detirmin what is in the list and in what order</param>
        public static void PrintFile (int line, FileInfo file, FileCategorys[] categorys)
        {
            PrintFile(line, file, categorys, TableLook.Default);
        }

        /// <summary>
        /// Print details about a file in a list form <see cref="ConsoleLists"/>
        /// </summary>
        /// <param name="line">the line to start printing at</param>
        /// <param name="file">FileInfo</param>
        /// <param name="style">how the list looks</param>
        public static void PrintFile (int line, FileInfo file, TableLook style)
        {
            PrintFile(line, file, new FileCategorys[] { FileCategorys.Name, FileCategorys.Extension, FileCategorys.Size, FileCategorys.FullPath }, style);
        }

        /// <summary>
        /// Print details about a file in a list form <see cref="ConsoleLists"/>
        /// </summary>
        /// <param name="line">the line to start printing at</param>
        /// <param name="path">path of the file to print</param>
        /// <param name="categorys">categorys that detirmin what is in the list and in what order</param>
        /// <param name="style">how the list looks</param>
        public static void PrintFile (int line, string path, FileCategorys[] categorys, TableLook style)
        {
            PrintFile(line, new FileInfo(path), categorys, style);
        }

        /// <summary>
        /// Print details about a file in a list form <see cref="ConsoleLists"/>
        /// </summary>
        /// <param name="line">the line to start printing at</param>
        /// <param name="file">FileInfo</param>
        /// <param name="categorys">categorys that detirmin what is in the list and in what order</param>
        /// <param name="style">how the list looks</param>
        public static void PrintFile (int line, FileInfo file, FileCategorys[] categorys, TableLook style)
        {
            if (!file.Exists || categorys.Length == 0)
                return;
            DataTable table = new();
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("Value", typeof(string));
            foreach (FileCategorys category in categorys)
            {
                string cat = category switch
                {
                    FileCategorys.Size => "File Size:",
                    FileCategorys.Name => "File Name:",
                    FileCategorys.Extension => "File Extension:",
                    FileCategorys.Atributes => "File Atributes:",
                    FileCategorys.CreationTime => "File Creation Date:",
                    FileCategorys.CreationTimeUtc => "File Creation Date Utc:",
                    FileCategorys.DirectoryPath => "Directory File Path:",
                    FileCategorys.Exists => "File Exists:",
                    FileCategorys.FullName => "Full File Name:",
                    FileCategorys.IsReadOnly => "Is File Readonly:",
                    FileCategorys.LastAcessTime => "File Last Acessed:",
                    FileCategorys.LastAcessTimeUtc => "File Last Acessed Utc:",
                    FileCategorys.LastWrittenTime => "File Last Changed:",
                    FileCategorys.LastWrittenTimeUtc => "File Last Changed Utc:",
                    FileCategorys.FolderName => "File Directory Name:",
                    FileCategorys.FullPath => "Full Path to the File:",
                    _ => "N/A"
                };
                string value = category switch
                {
                    FileCategorys.Size => Conversions.FormatSize(file.Length),
                    FileCategorys.Name => file.Name[..( file.Name.Length - file.Name.Split('.').Last().Length - 1 )],
                    FileCategorys.Extension => '.' + file.Name.Split('.').Last(),
                    FileCategorys.Atributes => file.Attributes.ToString(),
                    FileCategorys.CreationTime => file.CreationTime.ToString(),
                    FileCategorys.CreationTimeUtc => file.CreationTimeUtc.ToString(),
                    FileCategorys.DirectoryPath => file.DirectoryName,
                    FileCategorys.Exists => file.Exists.ToString(),
                    FileCategorys.FullName => file.Name,
                    FileCategorys.IsReadOnly => file.IsReadOnly.ToString(),
                    FileCategorys.LastAcessTime => file.LastAccessTime.ToString(),
                    FileCategorys.LastAcessTimeUtc => file.LastAccessTimeUtc.ToString(),
                    FileCategorys.LastWrittenTime => file.LastWriteTime.ToString(),
                    FileCategorys.LastWrittenTimeUtc => file.LastWriteTimeUtc.ToString(),
                    FileCategorys.FolderName => file.Directory.Name,
                    FileCategorys.FullPath => file.FullName,
                    _ => "N/A",
                };

                table.Rows.Add(new object[] { cat, value });
            }

            ConsoleLists.PrintSmartList(line, table, style, 5, true);
        }

        /// <summary>
        /// Some private Methods for PrintFolder Methods but some public ones if Needed for som reason
        /// (Can be unsafe as the methods are made for PrintFolder Methods)
        /// </summary>
        public static class Conversions
        {
            internal static string GetSortKey (IOSorting sort)
            {
                return sort switch
                {
                    IOSorting.SizeAsending => "Size ASC",
                    IOSorting.NameAsending => "Name ASC",
                    IOSorting.ExtensionAsending => "Extension ASC",
                    IOSorting.SizeDesending => "Size DESC",
                    IOSorting.NameDesending => "Name DESC",
                    IOSorting.ExtensionDesending => "Extension DESC",
                    IOSorting.NoSorting => string.Empty,
                    IOSorting.LastWritenDateAsending => "Last Written ASC",
                    IOSorting.LastWritenDateUtcAsending => "Last Written Utc ASC",
                    IOSorting.AtributesAsending => "Atributes ASC",
                    IOSorting.CreationDateAsending => "Creation Date ASC",
                    IOSorting.CreationDateUtcAsending => "Creation Date Utc ASC",
                    IOSorting.FileDirectoryAsending => "Directory ASC",
                    IOSorting.FileDirectoryNameAsending => "Directory Name ASC",
                    IOSorting.ExistsAsending => "Exists ASC",
                    IOSorting.FullNameAsending => "Full Name ASC",
                    IOSorting.IsReadOnlyAsending => "Read Only ASC",
                    IOSorting.LastAcessDateAsending => "Last Opened ASC",
                    IOSorting.LastAcessDateUtcAsending => "Last Opened Utc ASC",
                    IOSorting.LastWritenDateDesending => "Last Written",
                    IOSorting.LastWritenDateUtcDesending => "Last Written Utc",
                    IOSorting.AtributesDesending => "Atributes DESC",
                    IOSorting.CreationDateDesending => "Creation Date DESC",
                    IOSorting.CreationDateUtcDesending => "Creation Date Utc DESC",
                    IOSorting.FileDirectoryDesending => "Directory DESC",
                    IOSorting.FileDirectoryNameDesending => "Directory Name DESC",
                    IOSorting.ExistsDesending => "Exists DESC",
                    IOSorting.FullNameDesending => "Full Name DESC",
                    IOSorting.IsReadOnlyDesending => "Read Only DESC",
                    IOSorting.LastAcessDateDesending => "Last Opened DESC",
                    IOSorting.LastAcessDateUtcDesending => "Last Opened Utc DESC",
                    _ => string.Empty,
                };
            }

            /// <summary>
            /// Gets a table with all IOColums and files form the Folder
            /// </summary>
            /// <param name="dir">The FolderInfo</param>
            /// <param name="colums">The Colums countained in the table</param>
            /// <returns>DataTable with all files and folder from the folder with the info from the specefid IOColumns</returns>
            /// <exception cref="ArgumentOutOfRangeException">Should be imposible ust a defoult in a swich</exception>
            public static DataTable DirectoryAsTable (DirectoryInfo dir, IOColums[] colums)
            {
                DataTable table = new();
                FileInfo[] files = dir.GetFiles();
                DirectoryInfo[] directorys = dir.GetDirectories();

                foreach (IOColums colum in colums)
                {
                    (string colName, Type type) = colum switch
                    {
                        IOColums.Name => ("Name", typeof(string)),
                        IOColums.Size => ("Size", typeof(object)),
                        IOColums.Extension => ("Extension", typeof(string)),
                        IOColums.LastWritenDate => ("Last Written", typeof(DateTime)),
                        IOColums.LastWritenDateUtc => ("Last Written Utc", typeof(DateTime)),
                        IOColums.Atributes => ("Atributes", typeof(string)),
                        IOColums.CreationDate => ("Creation Date", typeof(DateTime)),
                        IOColums.CreationDateUtc => ("Creation Date Utc", typeof(DateTime)),
                        IOColums.FileDirectory => ("Directory", typeof(string)),
                        IOColums.FileDirectoryName => ("Directory Name", typeof(string)),
                        IOColums.Exists => ("Exists", typeof(bool)),
                        IOColums.FullName => ("Full Name", typeof(string)),
                        IOColums.IsReadOnly => ("Read Only", typeof(bool)),
                        IOColums.LastAcessDate => ("Last Opened", typeof(DateTime)),
                        IOColums.LastAcessDateUtc => ("Last Opened Utc", typeof(DateTime)),
                        _ => throw new ArgumentOutOfRangeException($"IMPOSIBLE this item ist countained in the enum {typeof(IOColums)}")
                    };
                    table.Columns.Add(colName, type);
                }

                foreach (DirectoryInfo directory in directorys)
                {
                    List<object> curRow = new();
                    foreach (IOColums col in colums)
                    {
                        curRow.Add(col switch
                        {
                            IOColums.Name => directory.Name,
                            IOColums.Size => string.Empty,
                            IOColums.Extension => "Folder",
                            IOColums.LastWritenDate => directory.LastWriteTime,
                            IOColums.LastWritenDateUtc => directory.LastWriteTimeUtc,
                            IOColums.Atributes => directory.Attributes,
                            IOColums.CreationDate => directory.CreationTime,
                            IOColums.CreationDateUtc => directory.CreationTimeUtc,
                            IOColums.FileDirectory => string.Empty,
                            IOColums.FileDirectoryName => string.Empty,
                            IOColums.Exists => directory.Exists,
                            IOColums.FullName => directory.FullName,
                            IOColums.IsReadOnly => string.Empty,
                            IOColums.LastAcessDate => directory.LastAccessTime,
                            IOColums.LastAcessDateUtc => directory.LastAccessTimeUtc,
                            _ => throw new ArgumentOutOfRangeException($"IMPOSIBLE this item ist countained in the enum {typeof(IOColums)}")
                        });
                    }
                    table.Rows.Add(curRow.ToArray());
                }

                foreach (FileInfo file in files)
                {
                    List<object> curRow = new();
                    foreach (IOColums col in colums)
                    {
                        curRow.Add(col switch
                        {
                            IOColums.Name => file.Name,
                            IOColums.Size => file.Length,
                            IOColums.Extension => file.Extension,
                            IOColums.LastWritenDate => file.LastWriteTime,
                            IOColums.LastWritenDateUtc => file.LastWriteTimeUtc,
                            IOColums.Atributes => file.Attributes,
                            IOColums.CreationDate => file.CreationTime,
                            IOColums.CreationDateUtc => file.CreationTimeUtc,
                            IOColums.FileDirectory => file.Directory,
                            IOColums.FileDirectoryName => file.DirectoryName,
                            IOColums.Exists => file.Exists,
                            IOColums.FullName => file.FullName,
                            IOColums.IsReadOnly => file.IsReadOnly,
                            IOColums.LastAcessDate => file.LastAccessTime,
                            IOColums.LastAcessDateUtc => file.LastAccessTimeUtc,
                            _ => throw new ArgumentOutOfRangeException($"IMPOSIBLE this item ist countained in the enum {typeof(IOColums)}")
                        });
                    }
                    table.Rows.Add(curRow.ToArray());
                }

                return table;
            }

            /// <summary>
            /// Gets a table with all IOColums and files form the Folder
            /// </summary>
            /// <param name="dir">The DirectoryInfo</param>
            /// <returns>DataTable with files and folders from the Folder with default IOColumns</returns>
            public static DataTable DirectoryAsTable (DirectoryInfo dir)
            {
                DataTable dt = new();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Extension", typeof(string));
                dt.Columns.Add("Size", typeof(object));
                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    dt.Rows.Add($"{d.Name}", "Folder", string.Empty);
                }
                foreach (FileInfo file in dir.GetFiles())
                {
                    dt.Rows.Add(file.Name, file.Extension, file.Length);
                }
                return dt;
            }

            internal static DataTable DataTableSizeFormat (DataTable table)
            {
                if (!table.Columns.Contains("Size"))
                    return table;
                foreach (DataRow row in table.Rows)
                {
                    if (long.TryParse(row["Size"].ToString(), out long size))
                    {
                        row["Size"] = size < 1000
                            ? $"{size} bytes"
                            : size < 1000000
                                ? $"{Math.Round(size / 1000d, 1)} KB"
                                : size < 1000000000
                                    ? $"{Math.Round(size / 1000000d, 1)} MB"
                                    : $"{Math.Round(size / 1000000000d, 1)} GB";
                    }
                }
                return table;
            }

            internal static string FormatSize (long size)
            {
                return size < 1000
                            ? $"{size} bytes"
                            : size < 1000000
                                ? $"{Math.Round(size / 1000d, 1)} KB"
                                : size < 1000000000
                                    ? $"{Math.Round(size / 1000000d, 1)} MB"
                                    : $"{Math.Round(size / 1000000000d, 1)} GB";
            }

            internal static bool ValidateSorting (IOSorting sort, IOColums[] colums)
            {
                if (sort == IOSorting.NoSorting)
                {
                    return false;
                }
                if (Enum.TryParse(sort.ToString().Replace("Asending", string.Empty).Replace("Desending", string.Empty), true, out IOColums col))
                {
                    if (colums.Contains(col))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }

    /// <summary>
    /// how a table is sortet by IOColums
    /// </summary>
    public enum IOSorting
    {
        NoSorting,
        NameAsending,
        SizeAsending,
        ExtensionAsending,
        LastWritenDateAsending,
        LastWritenDateUtcAsending,
        AtributesAsending,
        CreationDateAsending,
        CreationDateUtcAsending,
        FileDirectoryAsending,
        FileDirectoryNameAsending,
        ExistsAsending,
        FullNameAsending,
        IsReadOnlyAsending,
        LastAcessDateAsending,
        LastAcessDateUtcAsending,
        NameDesending,
        SizeDesending,
        ExtensionDesending,
        LastWritenDateDesending,
        LastWritenDateUtcDesending,
        AtributesDesending,
        CreationDateDesending,
        CreationDateUtcDesending,
        FileDirectoryDesending,
        FileDirectoryNameDesending,
        ExistsDesending,
        FullNameDesending,
        IsReadOnlyDesending,
        LastAcessDateDesending,
        LastAcessDateUtcDesending
    }

    /// <summary>
    /// Categorys that can be listet in a table displying a folder
    /// </summary>
    public enum IOColums
    {
        Name,
        Size,
        Extension,
        LastWritenDate,
        LastWritenDateUtc,
        Atributes,
        CreationDate,
        CreationDateUtc,
        FileDirectory,
        FileDirectoryName,
        Exists,
        FullName,
        IsReadOnly,
        LastAcessDate,
        LastAcessDateUtc
    }

    /// <summary>
    /// Categorys that can be listet in a table displaying a file
    /// </summary>
    public enum FileCategorys
    {
        Size,
        Name,
        Extension,
        Atributes,
        CreationTime,
        CreationTimeUtc,
        DirectoryPath,
        Exists,
        FullPath,
        FullName,
        IsReadOnly,
        LastAcessTime,
        LastAcessTimeUtc,
        LastWrittenTime,
        LastWrittenTimeUtc,
        FolderName
    }
}

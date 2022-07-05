using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleExtension
{
    public static class ConsoleIO
    {
        private static readonly IOColums[] DefaultColums = { IOColums.Name, IOColums.Extension, IOColums.Size };

        public static void PrintFolder (int line, string path)
        {
            if (!Directory.Exists(path))
            {
                ConsoleUtilities.ReplaceLine(line, $"Path \"{path}\" does not Exist...");
                return;
            }

            PrintFolder(line, new DirectoryInfo(path));
        }

        public static void PrintFolder (int line, DirectoryInfo dir)
        {
            ConsoleUtilities.ReplaceLine(line, $"Showing content of Directory \"{dir.FullName}\"");
            ConsoleTables.PrintTable(line + 1, Conversions.DataTableSizeFormat(Conversions.DirectoryAsTable(dir)), TableLook.DoubleLines, true);
        }

        public static void PrintFolder (int line, string path, IOSorting sort)
        {
            if (!Directory.Exists(path))
            {
                ConsoleUtilities.ReplaceLine(line, $"Path \"{path}\" does not Exist...");
                return;
            }

            PrintFolder(line, new DirectoryInfo(path), sort);
        }

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

        public static void PrintFolder (int line, string path, IOSorting sort, TableLook look)
        {
            if (!Directory.Exists(path))
            {
                ConsoleUtilities.ReplaceLine(line, $"Path \"{path}\" does not Exist...");
                return;
            }

            PrintFolder(line, new DirectoryInfo(path), sort, look);
        }

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

        public static void PrintFolder (int line, string path, IOSorting sort, TableLook look, IOColums[] colums)
        {
            if (!Directory.Exists(path))
            {
                ConsoleUtilities.ReplaceLine(line, $"Path \"{path}\" does not Exist...");
                return;
            }

            PrintFolder(line, new DirectoryInfo(path), sort, look, colums);
        }

        public static void PrintFolder (int line, string path, IOSorting sort, IOColums[] colums)
        {
            PrintFolder(line, path, sort, TableLook.DoubleLines, colums);
        }

        public static void PrintFolder (int line, DirectoryInfo dir, IOSorting sort, IOColums[] colums)
        {
            PrintFolder(line, dir, sort, TableLook.DoubleLines, colums);
        }

        public static void PrintFolder (int line, string path, IOColums[] colums)
        {
            PrintFolder(line, path, IOSorting.NoSorting, TableLook.DoubleLines, colums);
        }

        public static void PrintFolder (int line, DirectoryInfo dir, IOColums[] colums)
        {
            PrintFolder(line, dir, IOSorting.NoSorting, TableLook.DoubleLines, colums);
        }

        public static void PrintFolder (int line, string path, TableLook look, IOColums[] colums)
        {
            PrintFolder(line, path, IOSorting.NoSorting, look, colums);
        }

        public static void PrintFolder (int line, DirectoryInfo dir, TableLook look, IOColums[] colums)
        {
            PrintFolder(line, dir, IOSorting.NoSorting, look, colums);
        }

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
                    IOSorting.NoSorting => "",
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
                    _ => "",
                };
            }

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
                            IOColums.Size => "",
                            IOColums.Extension => "Folder",
                            IOColums.LastWritenDate => directory.LastWriteTime,
                            IOColums.LastWritenDateUtc => directory.LastWriteTimeUtc,
                            IOColums.Atributes => directory.Attributes,
                            IOColums.CreationDate => directory.CreationTime,
                            IOColums.CreationDateUtc => directory.CreationTimeUtc,
                            IOColums.FileDirectory => "",
                            IOColums.FileDirectoryName => "",
                            IOColums.Exists => directory.Exists,
                            IOColums.FullName => directory.FullName,
                            IOColums.IsReadOnly => "",
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

            public static DataTable DirectoryAsTable (DirectoryInfo dir)
            {
                DataTable dt = new();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Extension", typeof(string));
                dt.Columns.Add("Size", typeof(object));
                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    dt.Rows.Add($"{d.Name}", "Folder", "");
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

            internal static bool ValidateSorting (IOSorting sort, IOColums[] colums)
            {
                if (sort == IOSorting.NoSorting)
                {
                    return false;
                }
                if (Enum.TryParse(sort.ToString().Replace("Asending", "").Replace("Desending", ""), true, out IOColums col))
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
}

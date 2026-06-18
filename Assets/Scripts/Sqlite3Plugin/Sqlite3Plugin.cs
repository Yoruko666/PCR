using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Sqlite3Plugin
{
    public static class Plugin
    {
        private const string DLL_NAME = "sqlite3";

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_open(byte[] zFilename, out IntPtr ppDB);
        public static int sqlite3_open(byte[] zFilename, out IntPtr ppDB) { return ln_sqlite3_open(zFilename, out ppDB); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_open_v2(byte[] zFilename, out IntPtr ppDB, int flags, byte[] zVfs);
        public static int sqlite3_open_v2(byte[] zFilename, out IntPtr ppDB, int flags, byte[] zVfs) { return ln_sqlite3_open_v2(zFilename, out ppDB, flags, zVfs); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_close(IntPtr db);
        public static int sqlite3_close(IntPtr db) { return ln_sqlite3_close(db); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_exec(IntPtr db, byte[] zSql, IntPtr xCallback, IntPtr pArg, out IntPtr pzErrMsg);
        public static int sqlite3_exec(IntPtr db, byte[] zSql, IntPtr xCallback, IntPtr pArg, out IntPtr pzErrMsg) { return ln_sqlite3_exec(db, zSql, xCallback, pArg, out pzErrMsg); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_prepare_v2(IntPtr db, byte[] zSql, int nBytes, out IntPtr ppStmt, IntPtr pzTail);
        public static int sqlite3_prepare_v2(IntPtr db, byte[] zSql, int nBytes, out IntPtr ppStmt, IntPtr pzTail) { return ln_sqlite3_prepare_v2(db, zSql, nBytes, out ppStmt, pzTail); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_bind_text(IntPtr pStmt, int i, byte[] zData, int nData, IntPtr xDel);
        public static int sqlite3_bind_text(IntPtr pStmt, int i, byte[] zData, int nData, IntPtr xDel) { return ln_sqlite3_bind_text(pStmt, i, zData, nData, xDel); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_bind_blob(IntPtr pStmt, int i, byte[] zData, int nData, IntPtr xDel);
        public static int sqlite3_bind_blob(IntPtr pStmt, int i, byte[] zData, int nData, IntPtr xDel) { return ln_sqlite3_bind_blob(pStmt, i, zData, nData, xDel); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_bind_int(IntPtr pStmt, int i, int iValue);
        public static int sqlite3_bind_int(IntPtr pStmt, int i, int iValue) { return ln_sqlite3_bind_int(pStmt, i, iValue); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_bind_double(IntPtr pStmt, int i, double rValue);
        public static int sqlite3_bind_double(IntPtr pStmt, int i, double rValue) { return ln_sqlite3_bind_double(pStmt, i, rValue); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_bind_int64(IntPtr pStmt, int i, long lValue);
        public static int sqlite3_bind_int64(IntPtr pStmt, int i, long lValue) { return ln_sqlite3_bind_int64(pStmt, i, lValue); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_bind_null(IntPtr pStmt, int i);
        public static int sqlite3_bind_null(IntPtr pStmt, int i) { return ln_sqlite3_bind_null(pStmt, i); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_reset(IntPtr pStmt);
        public static int sqlite3_reset(IntPtr pStmt) { return ln_sqlite3_reset(pStmt); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_step(IntPtr pStmt);
        public static int sqlite3_step(IntPtr pStmt) { return ln_sqlite3_step(pStmt); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_finalize(IntPtr pStmt);
        public static int sqlite3_finalize(IntPtr pStmt) { return ln_sqlite3_finalize(pStmt); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_column_int(IntPtr pStmt, int i);
        public static int sqlite3_column_int(IntPtr pStmt, int i) { return ln_sqlite3_column_int(pStmt, i); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern long ln_sqlite3_column_int64(IntPtr pStmt, int i);
        public static long sqlite3_column_int64(IntPtr pStmt, int i) { return ln_sqlite3_column_int64(pStmt, i); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern double ln_sqlite3_column_double(IntPtr pStmt, int i);
        public static double sqlite3_column_double(IntPtr pStmt, int i) { return ln_sqlite3_column_double(pStmt, i); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_column_bytes(IntPtr pStmt, int i);
        public static int sqlite3_column_bytes(IntPtr pStmt, int i) { return ln_sqlite3_column_bytes(pStmt, i); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr ln_sqlite3_column_blob(IntPtr pStmt, int i);
        public static IntPtr sqlite3_column_blob(IntPtr pStmt, int i) { return ln_sqlite3_column_blob(pStmt, i); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr ln_sqlite3_column_text(IntPtr pStmt, int i);
        public static IntPtr sqlite3_column_text(IntPtr pStmt, int i) { return ln_sqlite3_column_text(pStmt, i); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_column_type(IntPtr pStmt, int i);
        public static int sqlite3_column_type(IntPtr pStmt, int i) { return ln_sqlite3_column_type(pStmt, i); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_vfs_register(IntPtr pStmt, int makeDflt);
        public static int sqlite3_vfs_register(IntPtr pStmt, int makeDflt) { return ln_sqlite3_vfs_register(pStmt, makeDflt); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_vfs_unregister(IntPtr pVfs);
        public static int sqlite3_vfs_unregister(IntPtr pVfs) { return ln_sqlite3_vfs_unregister(pVfs); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr ln_sqlite3_vfs_find(byte[] zVfsName);
        public static IntPtr sqlite3_vfs_find(byte[] zVfsName) { return ln_sqlite3_vfs_find(zVfsName); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_threadsafe();
        public static int sqlite3_threadsafe() { return ln_sqlite3_threadsafe(); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_wal_checkpoint_v2(IntPtr db, IntPtr zDb, int eMode, out int pnLog, out int pnCkpt);
        public static int sqlite3_wal_checkpoint_v2(IntPtr db, IntPtr zDb, int eMode, out int pnLog, out int pnCkpt) { return ln_sqlite3_wal_checkpoint_v2(db, zDb, eMode, out pnLog, out pnCkpt); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_wal_checkpoint(IntPtr db, IntPtr zDb);
        public static int sqlite3_wal_checkpoint(IntPtr db, IntPtr zDb) { return ln_sqlite3_wal_checkpoint(db, zDb); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_key(IntPtr db, byte[] pKey, int nKey);
        public static int sqlite3_key(IntPtr db, byte[] pKey, int nKey) { return ln_sqlite3_key(db, pKey, nKey); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_key_v2(IntPtr db, byte[] zDbName, byte[] pKey, int nKey);
        public static int sqlite3_key_v2(IntPtr db, byte[] zDbName, byte[] pKey, int nKey) { return ln_sqlite3_key_v2(db, zDbName, pKey, nKey); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_rekey(IntPtr db, byte[] pKey, int nKey);
        public static int sqlite3_rekey(IntPtr db, byte[] pKey, int nKey) { return ln_sqlite3_rekey(db, pKey, nKey); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3_rekey_v2(IntPtr db, byte[] zDbName, byte[] pKey, int nKey);
        public static int sqlite3_rekey_v2(IntPtr db, byte[] zDbName, byte[] pKey, int nKey) { return ln_sqlite3_rekey_v2(db, zDbName, pKey, nKey); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3mc_config(IntPtr db, byte[] paramName, int newValue);
        public static int sqlite3mc_config(IntPtr db, byte[] paramName, int newValue) { return ln_sqlite3mc_config(db, paramName, newValue); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ln_sqlite3mc_config_cipher(IntPtr db, byte[] cipherName, byte[] paramName, int newValue);
        public static int sqlite3mc_config_cipher(IntPtr db, byte[] cipherName, byte[] paramName, int newValue) { return ln_sqlite3mc_config_cipher(db, cipherName, paramName, newValue); }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr ln_sqlite3mc_codec_data(IntPtr db, byte[] schemaName, byte[] paramName);
        public static byte[] sqlite3mc_codec_data(IntPtr db, byte[] schemaName, byte[] paramName) { return ln_sqlite3mc_codec_data(db, schemaName, paramName); }
    }

    public class DatabaseCorruptionException : Exception
    {
        public DatabaseCorruptionException(int rc) : base("Database corrupted: " + rc) { }
    }

    public class DatabaseDiskFullException : Exception
    {
        public DatabaseDiskFullException() : base("Database disk full") { }
    }

    public class DatabaseIOErrorException : Exception
    {
        public DatabaseIOErrorException() : base("Database I/O error") { }
    }

    public static class ResultCode
    {
        public const int SQLITE_OK = 0;
        public const int SQLITE_ERROR = 1;
        public const int SQLITE_INTERNAL = 2;
        public const int SQLITE_PERM = 3;
        public const int SQLITE_ABORT = 4;
        public const int SQLITE_BUSY = 5;
        public const int SQLITE_LOCKED = 6;
        public const int SQLITE_NOMEM = 7;
        public const int SQLITE_READONLY = 8;
        public const int SQLITE_INTERRUPT = 9;
        public const int SQLITE_IOERR = 10;
        public const int SQLITE_CORRUPT = 11;
        public const int SQLITE_NOTFOUND = 12;
        public const int SQLITE_FULL = 13;
        public const int SQLITE_CANTOPEN = 14;
        public const int SQLITE_PROTOCOL = 15;
        public const int SQLITE_EMPTY = 16;
        public const int SQLITE_SCHEMA = 17;
        public const int SQLITE_TOOBIG = 18;
        public const int SQLITE_CONSTRAINT = 19;
        public const int SQLITE_MISMATCH = 20;
        public const int SQLITE_MISUSE = 21;
        public const int SQLITE_NOLFS = 22;
        public const int SQLITE_AUTH = 23;
        public const int SQLITE_FORMAT = 24;
        public const int SQLITE_RANGE = 25;
        public const int SQLITE_NOTADB = 26;
        public const int SQLITE_NOTICE = 27;
        public const int SQLITE_WARNING = 28;
        public const int SQLITE_ROW = 100;
        public const int SQLITE_DONE = 101;

        public static void CheckCriticalError(int rc, string errMsg)
        {
            if (rc == SQLITE_CORRUPT)
                throw new DatabaseCorruptionException(rc);
            if (rc == SQLITE_FULL)
                throw new DatabaseDiskFullException();
            if (rc == SQLITE_IOERR)
                throw new DatabaseIOErrorException();
            if (rc != SQLITE_OK)
                throw new Exception("SQLite error " + rc + ": " + errMsg);
        }
    }

    public static class Flags
    {
        public const int SQLITE_OPEN_READONLY = 1;
        public const int SQLITE_OPEN_READWRITE = 2;
        public const int SQLITE_OPEN_CREATE = 4;
        public const int SQLITE_OPEN_DELETEONCLOSE = 8;
        public const int SQLITE_OPEN_EXCLUSIVE = 16;
        public const int SQLITE_OPEN_AUTOPROXY = 32;
        public const int SQLITE_OPEN_URI = 64;
        public const int SQLITE_OPEN_MEMORY = 128;
        public const int SQLITE_OPEN_MAIN_DB = 256;
        public const int SQLITE_OPEN_TEMP_DB = 512;
        public const int SQLITE_OPEN_TRANSIENT_DB = 1024;
        public const int SQLITE_OPEN_MAIN_JOURNAL = 2048;
        public const int SQLITE_OPEN_TEMP_JOURNAL = 4096;
        public const int SQLITE_OPEN_SUBJOURNAL = 8192;
        public const int SQLITE_OPEN_SUPER_JOURNAL = 16384;
        public const int SQLITE_OPEN_NOMUTEX = 32768;
        public const int SQLITE_OPEN_FULLMUTEX = 65536;
        public const int SQLITE_OPEN_SHAREDCACHE = 131072;
        public const int SQLITE_OPEN_PRIVATECACHE = 262144;
        public const int SQLITE_OPEN_WAL = 524288;
        public const int SQLITE_OPEN_NOFOLLOW = 16777216;
    }

    public static class Config
    {
        public const int SQLITE_CONFIG_SINGLETHREAD = 1;
        public const int SQLITE_CONFIG_MULTITHREAD = 2;
        public const int SQLITE_CONFIG_SERIALIZED = 3;
        public const int SQLITE_CONFIG_MALLOC = 4;
        public const int SQLITE_CONFIG_GETMALLOC = 5;
        public const int SQLITE_CONFIG_SCRATCH = 6;
        public const int SQLITE_CONFIG_PAGECACHE = 7;
        public const int SQLITE_CONFIG_HEAP = 8;
        public const int SQLITE_CONFIG_MEMSTATUS = 9;
        public const int SQLITE_CONFIG_MUTEX = 10;
        public const int SQLITE_CONFIG_GETMUTEX = 11;
        public const int SQLITE_CONFIG_LOOKASIDE = 13;
        public const int SQLITE_CONFIG_PCACHE = 14;
        public const int SQLITE_CONFIG_GETPCACHE = 15;
        public const int SQLITE_CONFIG_LOG = 16;
        public const int SQLITE_CONFIG_URI = 17;
        public const int SQLITE_CONFIG_PCACHE2 = 18;
        public const int SQLITE_CONFIG_GETPCACHE2 = 19;
        public const int SQLITE_CONFIG_COVERING_INDEX_SCAN = 20;
        public const int SQLITE_CONFIG_SQLLOG = 21;
        public const int SQLITE_CONFIG_MMAP_SIZE = 22;
        public const int SQLITE_CONFIG_WIN32_HEAPSIZE = 23;
        public const int SQLITE_CONFIG_PCACHE_HDRSZ = 24;
        public const int SQLITE_CONFIG_PMASZ = 25;
        public const int SQLITE_CONFIG_STMTJRNL_SPILL = 26;
        public const int SQLITE_CONFIG_SMALL_MALLOC = 27;
        public const int SQLITE_CONFIG_SORTERREF_SIZE = 28;
        public const int SQLITE_CONFIG_MEMDB_MAXSIZE = 29;

        [Conditional("CYG_DEBUG")]
        public static void CheckPrerequisite() { }
    }

    public enum CIPHER_TYPE
    {
        CODEC_TYPE_AES128 = 1,
        CODEC_TYPE_AES256 = 2,
        CODEC_TYPE_CHACHA20 = 3,
        CODEC_TYPE_SQLCIPHER = 4,
        CODEC_TYPE_RC4 = 5,
    }

    public static class Cipher { }

    public class DBProxy : Connection
    {
        public DBProxy() { }
    }

    public class Connection : IDisposable
    {
        public IntPtr DBHandle { get; set; }
        public string dbPath { get; set; }

        public Connection() { }

        public bool IsOpened()
        {
            return DBHandle != IntPtr.Zero;
        }

        public bool Open(string fileName, string vfsName, byte[] key, CIPHER_TYPE cipherType = CIPHER_TYPE.CODEC_TYPE_CHACHA20)
        {
            dbPath = fileName;
            byte[] nameBytes = Encoding.UTF8.GetBytes(fileName);
            byte[] vfsBytes = vfsName != null ? Encoding.UTF8.GetBytes(vfsName) : null;
            int rc = Plugin.sqlite3_open_v2(nameBytes, out IntPtr db, Flags.SQLITE_OPEN_READONLY, vfsBytes);
            if (rc != ResultCode.SQLITE_OK)
                return false;
            DBHandle = db;

            if (key != null && key.Length > 0)
            {
                rc = Plugin.sqlite3_key(db, key, key.Length);
                if (rc != ResultCode.SQLITE_OK)
                {
                    Plugin.sqlite3_close(db);
                    DBHandle = IntPtr.Zero;
                    return false;
                }
            }
            return true;
        }

        public bool OpenWritable(string fileName, string journalMode = "MEMORY", string synchronouos = "1",
            string lockingMode = "EXCLUSIVE", bool enableSharedCache = false, byte[] key = null,
            CIPHER_TYPE cipherType = CIPHER_TYPE.CODEC_TYPE_CHACHA20)
        {
            dbPath = fileName;
            byte[] nameBytes = Encoding.UTF8.GetBytes(fileName);
            int flags = Flags.SQLITE_OPEN_READWRITE | Flags.SQLITE_OPEN_CREATE;
            int rc = Plugin.sqlite3_open_v2(nameBytes, out IntPtr db, flags, null);
            if (rc != ResultCode.SQLITE_OK)
                return false;
            DBHandle = db;

            if (key != null && key.Length > 0)
            {
                rc = Plugin.sqlite3_key(db, key, key.Length);
                if (rc != ResultCode.SQLITE_OK)
                {
                    Plugin.sqlite3_close(db);
                    DBHandle = IntPtr.Zero;
                    return false;
                }
            }

            Exec("PRAGMA journal_mode=" + journalMode);
            Exec("PRAGMA synchronous=" + synchronouos);
            Exec("PRAGMA locking_mode=" + lockingMode);
            if (enableSharedCache)
                Exec("PRAGMA cache=shared");
            return true;
        }

        public bool Begin(bool immediate = false)
        {
            return Exec(immediate ? "BEGIN IMMEDIATE" : "BEGIN");
        }

        public bool Commit()
        {
            return Exec("COMMIT");
        }

        public bool Checkpoint()
        {
            int rc = Plugin.sqlite3_wal_checkpoint(DBHandle, IntPtr.Zero);
            return rc == ResultCode.SQLITE_OK;
        }

        public bool Rollback()
        {
            return Exec("ROLLBACK");
        }

        public bool Vacuum()
        {
            return Exec("VACUUM");
        }

        public bool Analyze()
        {
            return Exec("ANALYZE");
        }

        public bool Exec(string sql)
        {
            byte[] sqlBytes = Encoding.UTF8.GetBytes(sql);
            int rc = Plugin.sqlite3_exec(DBHandle, sqlBytes, IntPtr.Zero, IntPtr.Zero, out IntPtr errMsg);
            if (rc != ResultCode.SQLITE_OK)
            {
                string msg = "unknown error";
                if (errMsg != IntPtr.Zero)
                {
                    int len = 0;
                    while (Marshal.ReadByte(errMsg, len) != 0) len++;
                    byte[] buf = new byte[len];
                    Marshal.Copy(errMsg, buf, 0, len);
                    msg = Encoding.UTF8.GetString(buf);
                }
                throw new Exception("SQLite exec error: " + msg);
            }
            return true;
        }

        public virtual void Dispose()
        {
            CloseDB();
        }

        protected override void Finalize()
        {
            Dispose();
        }

        public virtual void CloseDB()
        {
            if (DBHandle != IntPtr.Zero)
            {
                Plugin.sqlite3_close(DBHandle);
                DBHandle = IntPtr.Zero;
            }
        }

        public Query Query(string sql)
        {
            return new Query(this, sql);
        }

        public PreparedQuery PreparedQuery(string sql)
        {
            return new PreparedQuery(this, sql);
        }
    }

    public class Query : IDisposable
    {
        protected Connection _conn;
        protected IntPtr _stmt;

        public Query(Connection conn, string sql)
        {
            _Setup(conn, sql);
        }

        protected void _Setup(Connection conn, string sql)
        {
            _conn = conn;
            byte[] sqlBytes = Encoding.UTF8.GetBytes(sql);
            int rc = Plugin.sqlite3_prepare_v2(conn.DBHandle, sqlBytes, sqlBytes.Length, out _stmt, IntPtr.Zero);
            if (rc != ResultCode.SQLITE_OK)
            {
                _stmt = IntPtr.Zero;
                ThrowException(rc);
            }
        }

        private static void ThrowException(int rc)
        {
            switch (rc)
            {
                case ResultCode.SQLITE_CORRUPT:
                    throw new DatabaseCorruptionException(rc);
                case ResultCode.SQLITE_FULL:
                    throw new DatabaseDiskFullException();
                case ResultCode.SQLITE_IOERR:
                    throw new DatabaseIOErrorException();
                default:
                    throw new Exception("SQLite error: " + rc);
            }
        }

        public virtual void Dispose()
        {
            if (_stmt != IntPtr.Zero)
            {
                Plugin.sqlite3_finalize(_stmt);
                _stmt = IntPtr.Zero;
            }
        }

        public bool Step()
        {
            int rc = Plugin.sqlite3_step(_stmt);
            switch (rc)
            {
                case ResultCode.SQLITE_ROW:
                    return true;
                case ResultCode.SQLITE_DONE:
                    return false;
                default:
                    ThrowException(rc);
                    return false;
            }
        }

        public bool Exec()
        {
            while (Step()) { }
            return true;
        }

        public int GetInt(int idx)
        {
            return Plugin.sqlite3_column_int(_stmt, idx);
        }

        public long GetLong(int idx)
        {
            return Plugin.sqlite3_column_int64(_stmt, idx);
        }

        public double GetDouble(int idx)
        {
            return Plugin.sqlite3_column_double(_stmt, idx);
        }

        public string GetText(int idx)
        {
            IntPtr ptr = GetTextPtr(idx);
            if (ptr == IntPtr.Zero)
                return null;
            int len = Plugin.sqlite3_column_bytes(_stmt, idx);
            byte[] buf = new byte[len];
            Marshal.Copy(ptr, buf, 0, len);
            return Encoding.UTF8.GetString(buf);
        }

        public IntPtr GetTextPtr(int idx)
        {
            return Plugin.sqlite3_column_text(_stmt, idx);
        }

        public byte[] GetBlob(int idx)
        {
            IntPtr ptr = Plugin.sqlite3_column_blob(_stmt, idx);
            if (ptr == IntPtr.Zero)
                return null;
            int len = Plugin.sqlite3_column_bytes(_stmt, idx);
            byte[] buf = new byte[len];
            Marshal.Copy(ptr, buf, 0, len);
            return buf;
        }

        public bool IsNull(int idx)
        {
            return Plugin.sqlite3_column_type(_stmt, idx) == 5; // SQLITE_NULL
        }
    }

    public class PreparedQuery : Query
    {
        public PreparedQuery(Connection conn, string sql) : base(conn, sql) { }

        public bool BindText(int idx, string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            int rc = Plugin.sqlite3_bind_text(_stmt, idx, bytes, bytes.Length, new IntPtr(-1));
            return rc == ResultCode.SQLITE_OK;
        }

        public bool BindText(int idx, byte[] textBytes)
        {
            int rc = Plugin.sqlite3_bind_text(_stmt, idx, textBytes, textBytes.Length, new IntPtr(-1));
            return rc == ResultCode.SQLITE_OK;
        }

        public bool BindBlob(int idx, byte[] byteArray)
        {
            int rc = Plugin.sqlite3_bind_blob(_stmt, idx, byteArray, byteArray.Length, new IntPtr(-1));
            return rc == ResultCode.SQLITE_OK;
        }

        public bool BindInt(int idx, int iValue)
        {
            int rc = Plugin.sqlite3_bind_int(_stmt, idx, iValue);
            return rc == ResultCode.SQLITE_OK;
        }

        public bool BindDouble(int idx, double rValue)
        {
            int rc = Plugin.sqlite3_bind_double(_stmt, idx, rValue);
            return rc == ResultCode.SQLITE_OK;
        }

        public bool BindLong(int idx, long lValue)
        {
            int rc = Plugin.sqlite3_bind_int64(_stmt, idx, lValue);
            return rc == ResultCode.SQLITE_OK;
        }

        public bool Reset()
        {
            int rc = Plugin.sqlite3_reset(_stmt);
            return rc == ResultCode.SQLITE_OK;
        }
    }
}

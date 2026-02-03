namespace GoetheApp.ExceptionUtilities
{
    public class ExceptionDescriptionFormat
    {
        public const string DatabaseUniqueViolationFormat = "Unique constraint violation on table {0} for column {1}, Unique constraint {2}.";
        public const string DatabaseForeignKeyViolationFormat = "Foreign key violation on table {0} for column {1}. Foreign key {2}.";
        public const string DatabaseNotNullViolationFormat = "Not null constraint violation on column {0}, Table name {1}";
        public const string DatabaseUndefinedColumnFormat = "Undefined column in table {0} in schema {1}.";
        public const string DatabaseUndefinedTableFormat = "Undefined table {0} ";
        public const string DatabaseCheckViolationFormat = "Check constraint violation: {0}.";
        public const string DatabaseSyntaxErrorFormat = "Syntax error at position {0} Table {1}.";
        public const string DatabaseDeadLockDetectedFormat = "Deadlock detected: {0}. Hint: {1}.";
        public const string DatabaseGenericFormat = "Database Error: {0}. Detail: {1}.";
    }
}

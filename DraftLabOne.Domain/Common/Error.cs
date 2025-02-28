using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftLabOne.Domain.Common
{
    public class Error
    {
        public static readonly Error None = new(string.Empty, string.Empty);
        private const string Separator = "||";
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; set; }
        public string Message { get; set; }

        public string Serialize()
        {
            return $"{Code}{Separator}{Message}";
        }

        public static Error? Deserialize(string serialized)
        {
            var data = serialized.Split([Separator],StringSplitOptions.RemoveEmptyEntries);

            if (data.Length < 2)
                throw new($"Invalid error serialization: '{serialized}'");


            return new Error(data[0], data[1]); 
        }
    }

    public static class Errors
    {
        public static class General
        {
          public static Error Iternal(string message)
            {
                return new("iternal", message);
            }

            public static Error ValueIsInvalid(string? name = null)
            {
                var label = name ?? "Value";
                return new("value.is.invalid", $"{label} is invalid");
            }

            public static Error InvalidLength(string? name = null)
            {
                var label = name == null ? " " : " " + name + " ";
                return new("length.is.invalid", $"invalid{label}length");
            }

            public static Error ValueIsRequired(string? name = null)
            {
                var label = name ?? "Value";
                return new("value.is.required", $"{label} is required");
            }

            public static Error NoteAlreadyExists(string? name = null)
            {
                var label = name ?? "";
                return new("note.already.exists", $"note {label} has already been added");

            }

            public static Error NotFound(long? id = null)
            {
                var forId = id == null ? "" : $"for Id '{id}'";
                return new("record.not.found", $"record not found{forId}");
            }
        }
    }
}

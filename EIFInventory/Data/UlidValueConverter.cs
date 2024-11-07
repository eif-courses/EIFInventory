using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EIFInventory.Data;

public class UlidValueConverter() : ValueConverter<Ulid, string>(ulid => ulid.ToString(), str => Ulid.Parse(str));
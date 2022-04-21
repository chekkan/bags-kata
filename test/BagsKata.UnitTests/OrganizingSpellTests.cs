using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace BagsKata.UnitTests;

public class OrganizingSpellTests
{
		[Fact]
		public void OrganizingSpell_sorts_backpack_containing_clothes_by_name_asc()
		{
				var backpack = new Backpack();
				backpack.AddItems(Items.Silk, Items.Leather);

				var sorted = OrganizingSpell.Cast(backpack);
				sorted.Items.Select(i => i.Name).Should()
					.Equal(Items.Leather.Name, Items.Silk.Name)
					.And.BeInAscendingOrder();
		}
}

public record Backpack
{
		public IEnumerable<Item> Items { get; set; } = new List<Item>();
		
		public void AddItems(params Item[] items)
		{
			Items = Items.Concat(items);
		}
}

public static class Items
{
		public static Item Leather = new Item("Leather");
		public static Item Silk = new Item("Silk");
}

public record Item(string Name);

public static class OrganizingSpell
{
		public static Backpack Cast(Backpack backpack)
		{
				var result = new Backpack();
				result.AddItems(backpack.Items.OrderBy(i => i.Name).ToArray());
				return result;
		}
}


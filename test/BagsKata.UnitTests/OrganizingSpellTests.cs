using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace BagsKata.UnitTests;

public class OrganizingSpellTests
{
		[Fact]
		public void OrganizingSpell_sorts_items_into_backpack()
		{
			var backpack = OrganizingSpell.Cast(Items.Silk, Items.Leather, Items.Gold);
			backpack.Items.Select(i => i.Name).Should()
				.Equal(Items.Gold.Name, Items.Leather.Name, Items.Silk.Name)
				.And.BeInAscendingOrder();
		}
}

public record Backpack
{
		public IEnumerable<Item> Items { get; }

		public Backpack(IEnumerable<Item> items) => Items = items;
}

public static class Items
{
		public static Item Leather => new Item("Leather");
		public static Item Silk => new Item("Silk");
		public static Item Gold => new Item("Gold");
}

public record Item(string Name);

public static class OrganizingSpell
{
		public static Backpack Cast(params Item[] items) =>
			new Backpack(items.OrderBy(i => i.Name));
}


using System;

namespace HomeTaskSelenium.Entities
{

	public class Article : IEquatable<Article>
	{
		public string Title { get; set; }

		public Link Link { get; set; }

		public Article()
		{
			Link = new Link();
		}

		public bool Equals(Article other)
		{
			if (other == null)
			{
				return false;
			}

			if (this.Title == other.Title)
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Not equality of the specified objects
		/// </summary>
		/// <param name="obj1"></param>
		/// <param name="obj2"></param>
		/// <returns></returns>
		public static bool operator ==(Article obj1, Article obj2)
		{
			return obj1.Equals(obj2);
		}

		/// <summary>
		/// Equality of the specified objects
		/// </summary>
		/// <param name="obj1"></param>
		/// <param name="obj2"></param>
		/// <returns></returns>
		public static bool operator !=(Article obj1, Article obj2)
		{
			return !obj1.Equals(obj2);
		}

		/// <summary>
		/// Returns Hash Code of the current object
		/// </summary>
		public override int GetHashCode()
		{
			return base.GetHashCode() ^ Title.GetHashCode();
		}
	}
}

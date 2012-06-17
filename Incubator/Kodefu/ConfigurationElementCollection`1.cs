namespace Kodefu
{
    using System;
    using System.Configuration;
    using System.Collections.Generic;

    /// <summary>
    /// Generic class to be used in place of <see cref="System.Configuration.ConfigurationElementCollection"/>
    /// </summary>
    /// <typeparam name="T">A <see cref="ConfigurationElement"/> of which this class is a collection.</typeparam>
    /// <example>
    ///    [ConfigurationProperty("", IsDefaultCollection = true)]
    ///    [ConfigurationCollection(typeof(ConfigurationElementCollection&lt;DataTypeConfigurationElement&gt;),
    ///         AddItemName = "dataType", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    ///    public ConfigurationElementCollection&lt;DataTypeConfigurationElement&gt; DataTypes
    ///    {
    ///        get 
    ///        {
    ///            return (ConfigurationElementCollection&lt;DataTypeConfigurationElement&gt;)this[String.Empty];
    ///        }
    ///    }
    /// </example>
    /// <remarks>
    /// This class allows one to make a collection of a <see cref="ConfigurationElement"/> without
    /// having to create a specific class for each collection.
    /// </remarks>
    /// <author>Chris Eargle</author>
    public class ConfigurationElementCollection<T> : ConfigurationElementCollection, IEnumerable<T>
        where T : ConfigurationElement, new()
    {
        /// <summary>
        /// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new T();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element when overridden in a derived class.
        /// </summary>
        /// <param name="element">The <see cref="T:System.Configuration.ConfigurationElement"/> to return the key for.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            foreach (PropertyInformation property in element.ElementInformation.Properties)
            {
                if (property.IsKey)
                {
                    return property.Value;
                }
            }

            throw new Exception(typeof(T).ToString() + " does not contain property with IsKey set to true.");
        }

        /// <summary>
        /// Gets the <see cref="T"/> with the specified key.
        /// </summary>
        /// <value><see cref="T"/></value>
        /// <remarks>
        /// ConfigurationElements which contain integer keys will need to have the value boxed
        /// before passing into the indexer.
        /// </remarks>
        public T this[object key]
        {
            get
            {
                return (T)BaseGet(key);
            }
        }

        #region IEnumerable<T> Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public new IEnumerator<T> GetEnumerator()
        {
            var enumerator = base.GetEnumerator();

            while (enumerator.MoveNext())
            {
                yield return (T)enumerator.Current;
            }
        }

        #endregion
    }
}
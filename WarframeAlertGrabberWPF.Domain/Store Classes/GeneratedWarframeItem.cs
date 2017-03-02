
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class rss
{

    private rssChannel channelField;

    private decimal versionField;

    /// <remarks/>
    public rssChannel channel
    {
        get
        {
            return this.channelField;
        }
        set
        {
            this.channelField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal version
    {
        get
        {
            return this.versionField;
        }
        set
        {
            this.versionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class rssChannel
{

    private string titleField;

    private string linkField;

    private string descriptionField;

    private string languageField;

    private string copyrightField;

    private byte ttlField;

    private rssChannelItem[] itemField;

    /// <remarks/>
    public string title
    {
        get
        {
            return this.titleField;
        }
        set
        {
            this.titleField = value;
        }
    }

    /// <remarks/>
    public string link
    {
        get
        {
            return this.linkField;
        }
        set
        {
            this.linkField = value;
        }
    }

    /// <remarks/>
    public string description
    {
        get
        {
            return this.descriptionField;
        }
        set
        {
            this.descriptionField = value;
        }
    }

    /// <remarks/>
    public string language
    {
        get
        {
            return this.languageField;
        }
        set
        {
            this.languageField = value;
        }
    }

    /// <remarks/>
    public string copyright
    {
        get
        {
            return this.copyrightField;
        }
        set
        {
            this.copyrightField = value;
        }
    }

    /// <remarks/>
    public byte ttl
    {
        get
        {
            return this.ttlField;
        }
        set
        {
            this.ttlField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("item")]
    public rssChannelItem[] item
    {
        get
        {
            return this.itemField;
        }
        set
        {
            this.itemField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class rssChannelItem
{

    private string[] itemsField;

    private ItemsChoiceType[] itemsElementNameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("author", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("description", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("guid", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("expiry", typeof(string), Namespace = "http://warframe.com/rss/v1")]
    [System.Xml.Serialization.XmlElementAttribute("faction", typeof(string), Namespace = "http://warframe.com/rss/v1")]
    [System.Xml.Serialization.XmlElementAttribute("pubDate", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("title", typeof(string))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public string[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType[] ItemsElementName
    {
        get
        {
            return this.itemsElementNameField;
        }
        set
        {
            this.itemsElementNameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemsChoiceType
{

    /// <remarks/>
    author,

    /// <remarks/>
    description,

    /// <remarks/>
    guid,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("http://warframe.com/rss/v1:expiry")]
    expiry,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("http://warframe.com/rss/v1:faction")]
    faction,

    /// <remarks/>
    pubDate,

    /// <remarks/>
    title,
}

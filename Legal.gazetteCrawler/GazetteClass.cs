
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute("Gazette", IsNullable = false)]
public partial class Gazette
{

    private GazetteRecord[] recordField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Record")]
    public GazetteRecord[] Record
    {
        get
        {
            return this.recordField;
        }
        set
        {
            this.recordField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class GazetteRecord
{

    private string metaIdField;

    private string doc_Style_LNameField;

    private string doc_Style_SNameField;

    private string chapterField;

    private string pubGovField;

    private string pubGovNameField;

    private string undertakeGovField;

    private string officer_nameField;

    private string date_CreatedField;

    private string gazetteIdField;

    private string date_PublishedField;

    private string comment_DeadlineField;

    private string comment_DaysField;

    private string titleField;

    private string titleEnglishField;

    private string themeSubjectField;

    private string keywordField;

    private object eng_KeywordField;

    private string explainField;

    private string categoryField;

    private string cakeField;

    private string serviceField;

    private string gazetteHTMLField;

    private string hTMLContentField;

    /// <remarks/>
    public string MetaId
    {
        get
        {
            return this.metaIdField;
        }
        set
        {
            this.metaIdField = value;
        }
    }

    /// <remarks/>
    public string Doc_Style_LName
    {
        get
        {
            return this.doc_Style_LNameField;
        }
        set
        {
            this.doc_Style_LNameField = value;
        }
    }

    /// <remarks/>
    public string Doc_Style_SName
    {
        get
        {
            return this.doc_Style_SNameField;
        }
        set
        {
            this.doc_Style_SNameField = value;
        }
    }

    /// <remarks/>
    public string Chapter
    {
        get
        {
            return this.chapterField;
        }
        set
        {
            this.chapterField = value;
        }
    }

    /// <remarks/>
    public string PubGov
    {
        get
        {
            return this.pubGovField;
        }
        set
        {
            this.pubGovField = value;
        }
    }

    /// <remarks/>
    public string PubGovName
    {
        get
        {
            return this.pubGovNameField;
        }
        set
        {
            this.pubGovNameField = value;
        }
    }

    /// <remarks/>
    public string UndertakeGov
    {
        get
        {
            return this.undertakeGovField;
        }
        set
        {
            this.undertakeGovField = value;
        }
    }

    /// <remarks/>
    public string Officer_name
    {
        get
        {
            return this.officer_nameField;
        }
        set
        {
            this.officer_nameField = value;
        }
    }

    /// <remarks/>
    public string Date_Created
    {
        get
        {
            return this.date_CreatedField;
        }
        set
        {
            this.date_CreatedField = value;
        }
    }

    /// <remarks/>
    public string GazetteId
    {
        get
        {
            return this.gazetteIdField;
        }
        set
        {
            this.gazetteIdField = value;
        }
    }

    /// <remarks/>
    public string Date_Published
    {
        get
        {
            return this.date_PublishedField;
        }
        set
        {
            this.date_PublishedField = value;
        }
    }

    /// <remarks/>
    public string Comment_Deadline
    {
        get
        {
            return this.comment_DeadlineField;
        }
        set
        {
            this.comment_DeadlineField = value;
        }
    }

    /// <remarks/>
    public string Comment_Days
    {
        get
        {
            return this.comment_DaysField;
        }
        set
        {
            this.comment_DaysField = value;
        }
    }

    /// <remarks/>
    public string Title
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
    public string TitleEnglish
    {
        get
        {
            return this.titleEnglishField;
        }
        set
        {
            this.titleEnglishField = value;
        }
    }

    /// <remarks/>
    public string ThemeSubject
    {
        get
        {
            return this.themeSubjectField;
        }
        set
        {
            this.themeSubjectField = value;
        }
    }

    /// <remarks/>
    public string Keyword
    {
        get
        {
            return this.keywordField;
        }
        set
        {
            this.keywordField = value;
        }
    }

    /// <remarks/>
    public object Eng_Keyword
    {
        get
        {
            return this.eng_KeywordField;
        }
        set
        {
            this.eng_KeywordField = value;
        }
    }

    /// <remarks/>
    public string Explain
    {
        get
        {
            return this.explainField;
        }
        set
        {
            this.explainField = value;
        }
    }

    /// <remarks/>
    public string Category
    {
        get
        {
            return this.categoryField;
        }
        set
        {
            this.categoryField = value;
        }
    }

    /// <remarks/>
    public string Cake
    {
        get
        {
            return this.cakeField;
        }
        set
        {
            this.cakeField = value;
        }
    }

    /// <remarks/>
    public string Service
    {
        get
        {
            return this.serviceField;
        }
        set
        {
            this.serviceField = value;
        }
    }

    /// <remarks/>
    public string GazetteHTML
    {
        get
        {
            return this.gazetteHTMLField;
        }
        set
        {
            this.gazetteHTMLField = value;
        }
    }

    /// <remarks/>
    public string HTMLContent
    {
        get
        {
            return this.hTMLContentField;
        }
        set
        {
            this.hTMLContentField = value;
        }
    }
}


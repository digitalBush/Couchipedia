using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrewTurn.Wiki;
using ScrewTurn.Wiki.PluginFramework;

namespace Web.Helpers {
    public static class ViewHelpers {

        public class EmptySettings : ISettingsStorageProviderV30 {

            public ScrewTurn.Wiki.AclEngine.IAclManager AclManager {
                get { throw new NotImplementedException(); }
            }

            public bool AddRecentChange(string page, string title, string messageSubject, DateTime dateTime, string user, Change change, string descr) {
                throw new NotImplementedException();
            }

            public void BeginBulkUpdate() {
                throw new NotImplementedException();
            }

            public void ClearLog() {
                throw new NotImplementedException();
            }

            public bool DeleteOutgoingLinks(string page) {
                throw new NotImplementedException();
            }

            public bool DeletePluginAssembly(string filename) {
                throw new NotImplementedException();
            }

            public void EndBulkUpdate() {
                throw new NotImplementedException();
            }

            public IDictionary<string, string[]> GetAllOutgoingLinks() {
                throw new NotImplementedException();
            }

            public IDictionary<string, string> GetAllSettings() {
                throw new NotImplementedException();
            }

            public LogEntry[] GetLogEntries() {
                throw new NotImplementedException();
            }

            public string GetMetaDataItem(MetaDataItem item, string tag) {
                throw new NotImplementedException();
            }

            public string[] GetOutgoingLinks(string page) {
                throw new NotImplementedException();
            }

            public string GetPluginConfiguration(string typeName) {
                throw new NotImplementedException();
            }

            public bool GetPluginStatus(string typeName) {
                throw new NotImplementedException();
            }

            public RecentChange[] GetRecentChanges() {
                throw new NotImplementedException();
            }

            public string GetSetting(string name) {
                if (name == "DefaultPagesProvider")
                    return typeof(EmptyPagesProvider).FullName;
                return null;
            }

            public bool IsFirstApplicationStart() {
                throw new NotImplementedException();
            }

            public string[] ListPluginAssemblies() {
                throw new NotImplementedException();
            }

            public void LogEntry(string message, EntryType entryType, string user) {
                throw new NotImplementedException();
            }

            public int LogSize {
                get { throw new NotImplementedException(); }
            }

            public byte[] RetrievePluginAssembly(string filename) {
                throw new NotImplementedException();
            }

            public bool SetMetaDataItem(MetaDataItem item, string tag, string content) {
                throw new NotImplementedException();
            }

            public bool SetPluginConfiguration(string typeName, string config) {
                throw new NotImplementedException();
            }

            public bool SetPluginStatus(string typeName, bool enabled) {
                throw new NotImplementedException();
            }

            public bool SetSetting(string name, string value) {
                throw new NotImplementedException();
            }

            public bool StoreOutgoingLinks(string page, string[] outgoingLinks) {
                throw new NotImplementedException();
            }

            public bool StorePluginAssembly(string filename, byte[] assembly) {
                throw new NotImplementedException();
            }

            public bool UpdateOutgoingLinksForRename(string oldName, string newName) {
                throw new NotImplementedException();
            }

            public string ConfigHelpHtml {
                get { throw new NotImplementedException(); }
            }

            public ComponentInformation Information {
                get { throw new NotImplementedException(); }
            }

            public void Init(IHostV30 host, string config) {
                throw new NotImplementedException();
            }

            public void Shutdown() {
                throw new NotImplementedException();
            }
        }

        public class EmptyPagesProvider : IPagesStorageProviderV30 {
            public CategoryInfo AddCategory(string nspace, string name) {
                throw new NotImplementedException();
            }

            public ContentTemplate AddContentTemplate(string name, string content) {
                throw new NotImplementedException();
            }

            public bool AddMessage(PageInfo page, string username, string subject, DateTime dateTime, string body, int parent) {
                throw new NotImplementedException();
            }

            public NamespaceInfo AddNamespace(string name) {
                throw new NotImplementedException();
            }

            public NavigationPath AddNavigationPath(string nspace, string name, PageInfo[] pages) {
                throw new NotImplementedException();
            }

            public PageInfo AddPage(string nspace, string name, DateTime creationDateTime) {
                throw new NotImplementedException();
            }

            public Snippet AddSnippet(string name, string content) {
                throw new NotImplementedException();
            }

            public bool BulkStoreMessages(PageInfo page, Message[] messages) {
                throw new NotImplementedException();
            }

            public bool DeleteBackups(PageInfo page, int revision) {
                throw new NotImplementedException();
            }

            public bool DeleteDraft(PageInfo page) {
                throw new NotImplementedException();
            }

            public PageContent GetBackupContent(PageInfo page, int revision) {
                throw new NotImplementedException();
            }

            public int[] GetBackups(PageInfo page) {
                throw new NotImplementedException();
            }

            public CategoryInfo[] GetCategories(NamespaceInfo nspace) {
                throw new NotImplementedException();
            }

            public CategoryInfo[] GetCategoriesForPage(PageInfo page) {
                throw new NotImplementedException();
            }

            public CategoryInfo GetCategory(string fullName) {
                throw new NotImplementedException();
            }

            public PageContent GetContent(PageInfo page) {
                throw new NotImplementedException();
            }

            public ContentTemplate[] GetContentTemplates() {
                throw new NotImplementedException();
            }

            public PageContent GetDraft(PageInfo page) {
                throw new NotImplementedException();
            }

            public void GetIndexStats(out int documentCount, out int wordCount, out int occurrenceCount, out long size) {
                throw new NotImplementedException();
            }

            public int GetMessageCount(PageInfo page) {
                throw new NotImplementedException();
            }

            public Message[] GetMessages(PageInfo page) {
                throw new NotImplementedException();
            }

            public NamespaceInfo GetNamespace(string name) {
                throw new NotImplementedException();
            }

            public NamespaceInfo[] GetNamespaces() {
                throw new NotImplementedException();
            }

            public NavigationPath[] GetNavigationPaths(NamespaceInfo nspace) {
                throw new NotImplementedException();
            }

            public PageInfo GetPage(string fullName) {
                return null;
            }

            public PageInfo[] GetPages(NamespaceInfo nspace) {
                throw new NotImplementedException();
            }

            public Snippet[] GetSnippets() {
                throw new NotImplementedException();
            }

            public PageInfo[] GetUncategorizedPages(NamespaceInfo nspace) {
                throw new NotImplementedException();
            }

            public bool IsIndexCorrupted {
                get { throw new NotImplementedException(); }
            }

            public CategoryInfo MergeCategories(CategoryInfo source, CategoryInfo destination) {
                throw new NotImplementedException();
            }

            public ContentTemplate ModifyContentTemplate(string name, string content) {
                throw new NotImplementedException();
            }

            public bool ModifyMessage(PageInfo page, int id, string username, string subject, DateTime dateTime, string body) {
                throw new NotImplementedException();
            }

            public NavigationPath ModifyNavigationPath(NavigationPath path, PageInfo[] pages) {
                throw new NotImplementedException();
            }

            public bool ModifyPage(PageInfo page, string title, string username, DateTime dateTime, string comment, string content, string[] keywords, string description, SaveMode saveMode) {
                throw new NotImplementedException();
            }

            public Snippet ModifySnippet(string name, string content) {
                throw new NotImplementedException();
            }

            public PageInfo MovePage(PageInfo page, NamespaceInfo destination, bool copyCategories) {
                throw new NotImplementedException();
            }

            public ScrewTurn.Wiki.SearchEngine.SearchResultCollection PerformSearch(ScrewTurn.Wiki.SearchEngine.SearchParameters parameters) {
                throw new NotImplementedException();
            }

            public bool RebindPage(PageInfo page, string[] categories) {
                throw new NotImplementedException();
            }

            public void RebuildIndex() {
                throw new NotImplementedException();
            }

            public bool RemoveCategory(CategoryInfo category) {
                throw new NotImplementedException();
            }

            public bool RemoveContentTemplate(string name) {
                throw new NotImplementedException();
            }

            public bool RemoveMessage(PageInfo page, int id, bool removeReplies) {
                throw new NotImplementedException();
            }

            public bool RemoveNamespace(NamespaceInfo nspace) {
                throw new NotImplementedException();
            }

            public bool RemoveNavigationPath(NavigationPath path) {
                throw new NotImplementedException();
            }

            public bool RemovePage(PageInfo page) {
                throw new NotImplementedException();
            }

            public bool RemoveSnippet(string name) {
                throw new NotImplementedException();
            }

            public CategoryInfo RenameCategory(CategoryInfo category, string newName) {
                throw new NotImplementedException();
            }

            public NamespaceInfo RenameNamespace(NamespaceInfo nspace, string newName) {
                throw new NotImplementedException();
            }

            public PageInfo RenamePage(PageInfo page, string newName) {
                throw new NotImplementedException();
            }

            public bool RollbackPage(PageInfo page, int revision) {
                throw new NotImplementedException();
            }

            public bool SetBackupContent(PageContent content, int revision) {
                throw new NotImplementedException();
            }

            public NamespaceInfo SetNamespaceDefaultPage(NamespaceInfo nspace, PageInfo page) {
                throw new NotImplementedException();
            }

            public bool ReadOnly {
                get { throw new NotImplementedException(); }
            }

            public string ConfigHelpHtml {
                get { throw new NotImplementedException(); }
            }

            public ComponentInformation Information {
                get { throw new NotImplementedException(); }
            }

            public void Init(IHostV30 host, string config) {
                throw new NotImplementedException();
            }

            public void Shutdown() {
                throw new NotImplementedException();
            }
        }
        static ViewHelpers() {
            Collectors.SettingsProvider = new EmptySettings();
            Collectors.PagesProviderCollector = new ProviderCollector<IPagesStorageProviderV30>();
            Collectors.PagesProviderCollector.AddProvider(new EmptyPagesProvider());
        }

        public static MvcHtmlString RenderMarkdown(this HtmlHelper helper, string input) {
            return MvcHtmlString.Create(Formatter.Format(input, false, FormattingContext.Unknown, null).Replace(".ashx",""));
        } 
    }
}
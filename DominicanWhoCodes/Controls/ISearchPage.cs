using System;
namespace DominicanWhoCodes.Controls
{
    public interface ISearchPage
    {
        void OnSearchBarTextChanged(string text);
        event EventHandler<string> SearchBarTextChanged;
    }
}

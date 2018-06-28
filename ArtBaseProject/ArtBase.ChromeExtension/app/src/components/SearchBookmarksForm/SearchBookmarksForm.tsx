import * as React from 'react';
import { LoadingSpinner, SearchBar, DAL } from 'artbase-common';
import { BookmarksList } from './BookmarksList';

export interface ISearchBookmarksFormState {
    lastBookmarks: any;
    filteredBookmarks: any;
    inputText: string;
    checkIfSearched: boolean;
    lastBookmarksLoaded: boolean;
    searchedBookmarksLoaded: boolean;
}

export interface ISearchBookmarksFormProps { }

export class SearchBookmarksForm extends React.Component<ISearchBookmarksFormProps, ISearchBookmarksFormState> {

    constructor(props: ISearchBookmarksFormProps) {
        super(props);
        this.state = {
            lastBookmarks: [],
            filteredBookmarks: [],
            inputText: '',
            checkIfSearched: false,
            lastBookmarksLoaded: false,
            searchedBookmarksLoaded: false,
        };
    }

    componentDidMount() {
        DAL.getLastBookmarks(5).then((res: any) => {
            this.setState({
                lastBookmarks: res.data,
                lastBookmarksLoaded: true,
                searchedBookmarksLoaded: true,
            });
        });
    }

    private getSearchedBookmarks = (searchInput: string) => {
        if (searchInput.length > 1) {
            this.setState({
                searchedBookmarksLoaded: false,
            });
            DAL.getSearchedBookmarks(searchInput).then((res: any) => {
                this.setState({
                    filteredBookmarks: res.data,
                    checkIfSearched: true,
                    searchedBookmarksLoaded: true,
                });
            });
        }
        else {
            this.setState({
                checkIfSearched: false,
            });
        }
        this.setState({
            inputText: searchInput,
        });
    }

    render() {
        if (this.state.lastBookmarksLoaded) {
            let bookmarkList = <BookmarksList bookmarks={this.state.checkIfSearched ? this.state.filteredBookmarks : this.state.lastBookmarks} />;
            if (!this.state.searchedBookmarksLoaded) {
                bookmarkList = <LoadingSpinner />
            }
            return (
                <div className='artB-SearchBookmarksForm'>
                    <SearchBar onSearch={this.getSearchedBookmarks} inputText={this.state.inputText} />
                    {bookmarkList}
                </div>
            );
        }
        return <LoadingSpinner />
    }
}
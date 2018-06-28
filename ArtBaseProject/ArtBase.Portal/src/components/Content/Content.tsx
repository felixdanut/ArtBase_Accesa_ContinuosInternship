import * as React from 'react';
import './Content.css';
import { SearchBar } from 'artbase-common';
import { Bookmark } from './Bookmark';
import { AddButton } from '../Common/AddButton';

export interface IContentState { 
    inputText: string;
}

export interface IContentProps { 
    bookmarks: any;
}

export class Content extends React.Component<IContentProps, IContentState> {

    constructor(props: IContentProps) {
        super(props);
        this.state = {
            inputText: '',
        };
    }

    private getSearchedBookmarks = () => {

    }

    render() {
        return (
            <div className='artB-Content'>
                <SearchBar onSearch={this.getSearchedBookmarks} inputText={this.state.inputText} />
                {
                    this.props.bookmarks.map((bookmark: any, index: number) => (
                        <div key={index}>
                            <Bookmark title={bookmark.title} url={bookmark.url} />
                        </div>
                    ))
                }
                <AddButton onClick={() => {}} />
            </div>
        );
    }
}
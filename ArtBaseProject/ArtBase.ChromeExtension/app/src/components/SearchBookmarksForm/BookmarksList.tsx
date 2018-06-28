import * as React from 'react';
import './SearchBookmarksForm.css';
import { LoadingSpinner } from 'artbase-common';

export interface IBookmarksListProps {
    bookmarks: any;
}

export class BookmarksList extends React.Component<IBookmarksListProps, any> {

    constructor(props: IBookmarksListProps) {
        super(props);
    }

    render() {
        if (this.props.bookmarks) {
            return (
                <div className='artB-BookmarksList'>
                    <ul>
                        {
                            this.props.bookmarks.map((bookmark: any) => (
                                <li key={bookmark.id}><a target="_blank" href={bookmark.url}>{bookmark.title}</a></li>
                            ))
                        }
                    </ul>
                </div>
            );
        }
        return <LoadingSpinner/>;
    }
}
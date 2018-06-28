import * as React from 'react';
import './Portal.css';
import { Logo } from '../Common/Logo';
import { CategorySideBar } from '../CategorySideBar/CategorySideBar';
import { Content } from '../Content/Content';
import { TagsSideBar } from '../TagsSideBar/TagsSideBar';
import { LoadingSpinner, DAL, TabbedNavigation, ITabInfo } from 'artbase-common';

export interface IPortalState { 
    bookmarks: any;
    categories: any;
    tags: any;
    bookmarksLoaded: boolean;
}

export interface IPortalProps { }

export class Portal extends React.Component<IPortalProps, IPortalState> {

    constructor(props: IPortalProps) {
        super(props);
        this.state = {
            bookmarks: [],
            categories: [],
            tags: [],
            bookmarksLoaded: true,
        };
    }

    componentDidMount() {
        DAL.getLastBookmarks(5).then((res: any) => {
            this.setState({
                bookmarks: res.data,
                bookmarksLoaded: true
            });
        });

        DAL.getCategories().then((res: any) => {
            this.setState({
                categories: res.data
            })
        });

        DAL.getTags().then((res: any) => {
            this.setState({
                tags: res.data
            })
        });
    }

    private tabs: ITabInfo[] = [
        {
            name: "All",
            icon: "/../../Content/img/2.png",
            onClick: this.getAllBookmarks
        },
        {
            name: "My Links",
            icon: "/../../Content/img/6.png",
            onClick: this.getMyLinks
        },
        {
            name: "My Claps",
            icon: "/../../Content/img/4.png",
            onClick: this.getMyClaps
        }
    ]

    private getByCategory() {

    }

    private getByMainOption() {

    }

    private getByTags() {

    }

    private getAllBookmarks() {

    }

    private getMyLinks() {

    }

    private getMyClaps() {

    }

    render() {
        if (this.state.bookmarksLoaded) {
            return (
                <div className='artB-Portal'>
                    <Logo />
                    <TabbedNavigation tabs={this.tabs} />
                    <CategorySideBar onSelectedValueChanged={this.getByCategory} options={this.state.categories} />
                    <Content bookmarks={this.state.bookmarks} />
                    <TagsSideBar onSelectedValueChanged={this.getByTags} tags={this.state.tags} />
                </div>
            );
        }
        return <LoadingSpinner />
    }
}
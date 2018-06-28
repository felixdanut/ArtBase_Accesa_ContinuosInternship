import * as React from 'react';
import './Common.css';
export interface ISearchBarProps {
    onSearch: any;
    inputText: string;
}
export interface ISearchBarState {
    value: string;
}
export declare class SearchBar extends React.Component<ISearchBarProps, ISearchBarState> {
    constructor(props: ISearchBarProps);
    private debounce;
    private onChange;
    private search;
    render(): JSX.Element;
}

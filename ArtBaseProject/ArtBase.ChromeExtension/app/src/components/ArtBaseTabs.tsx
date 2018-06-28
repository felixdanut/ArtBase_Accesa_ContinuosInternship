import * as React from 'react';

import { TabbedNavigation, ITabInfo } from 'artbase-common';
import { SaveBookmarkForm } from './SaveBookmarkForm/SaveBookmarkForm';
import { SearchBookmarksForm } from './SearchBookmarksForm/SearchBookmarksForm';

export interface IArtBaseTabsProps { }

export interface IArtBaseTabsState {
  showSearchForm: boolean;
}

export default class ArtBaseTabs extends React.Component<IArtBaseTabsProps, IArtBaseTabsState> {

  constructor(props: IArtBaseTabsProps) {
    super(props);
    this.state = {
      showSearchForm: false
    };
  }

  private changeDisplay = (showSearchForm: boolean) => {
    this.setState({ showSearchForm: showSearchForm });
  }

  private showSearch = () => {
    this.changeDisplay(true);
  }

  private showSave = () => {
    this.changeDisplay(false);
  }

  private tabs: ITabInfo[] = [
    {
      name: 'Save',
      icon: '',
      onClick: this.showSave
    },
    {
      name: 'Search',
      icon: '',
      onClick: this.showSearch
    }
  ]

  render() {
    return (
      <div>
        <TabbedNavigation tabs={this.tabs} />
        <div>
          {this.state.showSearchForm ? <SearchBookmarksForm /> : <SaveBookmarkForm />}
        </div>
      </div>
    );
  }
}


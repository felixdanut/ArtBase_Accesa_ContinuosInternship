import * as React from 'react';
import './Common.css';

export class LoadingSpinner extends React.Component<any, any> {
    render() {
        return (
            <div className='artB-spinner'>
                <div className='artB-cube1'></div>
                <div className='artB-cube2'></div>
            </div>
        );
    }
}
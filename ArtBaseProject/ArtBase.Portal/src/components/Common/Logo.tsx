import * as React from 'react';
import './Common.css';

export class Logo extends React.Component<any> {

    render() {
        return (
            <div className='artB-Logo'>
                <img className="artB-ImageLogo" src="https://theartbase.org/wp-content/uploads/2016/03/TAB_2-Color.png" 
                alt="logo"/>
            </div>
        );
    }
}
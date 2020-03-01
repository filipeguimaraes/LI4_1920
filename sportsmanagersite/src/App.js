import React from 'react';
import './App.css';
import { Layout, Header, Navigation, Drawer, Content } from 'react-mdl';
import Main from './components/main';
import { Link } from 'react-router-dom';

function App() {
  return (
<div className="demo-big-content">
    <Layout>
        <Header className="header-color" title="Sports Manager" scroll>
            <Navigation>
                <Link to="/login">Log in</Link>
                <Link to="/signup">Sign up</Link>
                <Link to="/contact">Contact us</Link>
            </Navigation>
        </Header>
        <Drawer title="Sports Manager" style={{color: '#85D8CE'}}>
            <Navigation>
                <Link to="/login" style={{color: '#85D8CE'}}>Log in</Link>
                <Link to="/signup" style={{color: '#85D8CE'}}>Sign up</Link>
                <Link to="/contact" style={{color: '#85D8CE'}}>Contact us</Link>
            </Navigation>
        </Drawer>
        <Content>
            <div className="page-content" />
            <Main/>
        </Content>
    </Layout>
</div>
  );
}

export default App;








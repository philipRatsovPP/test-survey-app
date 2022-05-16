import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Surveys } from './components/Surveys';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Surveys} />
        <Route path='/surveys' component={Surveys} />
      </Layout>
    );
  }
}

import React, { Component } from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Surveys } from './components/Surveys';
import { SurveyDetailsPage } from './components/SurveyDetailsPage';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Surveys} />
        <Route path='/surveys' component={Surveys} />
        <Route path='/surveys/:id' component={SurveyDetailsPage} />
        {/* <Route path='/surveys/id'>
          <SurveyDetailsPage />
        </Route> */}
      </Layout>
    );
  }
}

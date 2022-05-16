import React, { Component } from 'react';

export class Surveys extends Component {
  static displayName = Surveys.name;

  constructor(props) {
    super(props);
    this.state = { surveys: [], loading: true };
  }

  componentDidMount() {
    this.listSurveys();
  }

  static renderSurveys(surveys) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
          </tr>
        </thead>
        <tbody>
          {surveys.map(survey =>
            <tr key={survey.name}>
              <td>{survey.name}</td>
              <td>
                <a href={`/surveys/${survey.id}`}>Details</a>
              </td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Surveys.renderSurveys(this.state.surveys);

    return (
      <div>
        <h1 id="tabelLabel" >Survey Monkey</h1>
        {contents}
      </div>
    );
  }


  async listSurveys() {
    const response = await fetch('survey/surveys');
    const data = await response.json();
    this.setState({ surveys: data.surveys, loading: false });

  }
}

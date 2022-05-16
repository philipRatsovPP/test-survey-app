import React, { Component } from 'react';
import { NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';

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
                <NavLink tag={Link} className="text-dark" to={`/surveys/${survey.id}`}>Details</NavLink>
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
        <h2 id="tabelLabel" >All surveys</h2>
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

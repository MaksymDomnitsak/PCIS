import React, { Component } from 'react';
import { Link } from "react-router-dom";

export class Positions extends Component {
    static displayName = Positions.name;

    constructor(props) {
        super(props);
        this.state = { positions: [], loading: true };
    }

    componentDidMount() {
        this.readPositions();
    }

    static renderPositionsTable(positions) {
        return (
        <table className='table table-striped' aria-labelledby="tableLabel">
        <thead>
          <tr>
            <th>Name</th>
          </tr>
        </thead>
        <tbody>
          {positions.map(position =>
            <tr key={position.name}>
              <td>{position.name}</td>
            </tr>
          )}
        </tbody>
        </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Positions.renderPositionsTable(this.state.positions);

        return (
            <div>
                <h1 id="tableLabel" >Positions</h1>
                <p>
                    <Link to="/addposition">Create New</Link>
                </p>
                {contents}
            </div>
        );
    }

    async readPositions() {
        const response = await fetch('/api/Positions');
        const data = await response.json();
        this.setState({ positions: data, loading: false });
  }
}
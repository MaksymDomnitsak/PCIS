import React, { Component } from 'react';

export class AddPosition extends Component {
    static displayName = AddPosition.name;

    constructor(props) {
        super(props);
        this.state = { positions: [], loading: true };

        this.handleSave = this.handleSave.bind(this);
        this.handleCancel = this.handleCancel.bind(this);
    }


    handleSave(event) {
        event.preventDefault();
        const data = new FormData(event.target);
                fetch('api/Positions', {
                    method: 'POST',
                    body: data,  
                }).then((response) => response.json())  
                .then((responseJson) => {
                    this.props.history.push("/positions");  
                })
    }

    handleCancel(e) {
        e.preventDefault();
        this.props.history.push("/positions");  
    }

    render() {
        let contents = this.renderCreateForm()

        return (
            <div>
                <h1 id="tableLabel" >Positions</h1>
                <p></p>
                {contents}
            </div>
        );
    }
    renderCreateForm() {
        return (
            <form onSubmit={this.handleSave} >
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="Name">Name</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="name" required />
                    </div>
                </div>
                <div className="form-group">
                    <button type="submit" className="btn btn-default">Save</button>
                    <button className="btn" onClick={this.handleCancel}>Cancel</button>
                </div>
            </form>
        )
    }
}
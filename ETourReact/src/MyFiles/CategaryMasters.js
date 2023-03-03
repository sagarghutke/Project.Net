import { Component } from "react";
import PostCategaryMasters from "./PostCategaryMasters";
import { Table } from "react-bootstrap";

class CategaryMasters extends Component{

  state ={
    categaries : []
  }

  componentDidMount(){
    fetch("http://localhost:5281/api/categarymasters").then(res => res.json()).then((result) => { 
        this.setState({categaries : result});
      });
  }

  render(){
    return(
      <div>
        <h2>Categaries......</h2>
        
        <Table striped bordered hover>
      <thead>
        <tr>
          <th>catMasterIid</th>
          <th>catId</th>
          <th>subcatId</th>
          <th>catName</th>
          <th>catImagePath</th>
        </tr>
      </thead>
      <tbody>
        { this.state.categaries.map(cat => (
          <tr key={cat.catMasterIid}>
            <td>{cat.catMasterIid}</td>
            <td>{cat.catId}</td>
            <td>{cat.subcatId}</td>
            <td>{cat.catName}</td>
            <td>{cat.catImpPath}</td>
          </tr>
        ))
        }
      </tbody>
    </Table>
        
        
        
        {/* <table>
          <thead>
            <tr>
              <th>catMasterIid</th>
              <th>catId</th>
              <th>subcatId</th>
              <th>catName</th>
              <th>catImagePath</th>
            </tr>
          </thead>

          <tbody>
            {this.state.categaries.map(cat => (
              <tr key={cat.catMasterIid}>
                <td>{cat.catMasterIid}</td>
                <td>{cat.catId}</td>
                <td>{cat.subcatId}</td>
                <td>{cat.catName}</td>
                <td>{cat.catImpPath}</td>
              </tr>
            ))}
          </tbody>
          
        </table> */}
        <PostCategaryMasters/>
      </div>
    )
  }
}
export default CategaryMasters ;
 


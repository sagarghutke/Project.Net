import { useEffect, useState } from 'react';
import { Button } from 'react-bootstrap';
import Table from 'react-bootstrap/Table';

function GetCategaryMasters (){

const [Categary, setCategary] = useState([]);


useEffect( () => {
  fetch("https:/localhost:7014/api/Category_Master").then(res => res.json())
  .then(result => {
    setCategary(result);
  } 
  );
  }, []);

 return(
    <div style={{width: "75%",marginLeft:"180px"}}>
      <h3 style={{}}>Categary Table Data</h3>
    <Table striped bordered hover >
      <thead>
        <tr>
          <th>catMasterIid</th>
          <th>catId</th>
          <th>subcatId</th>
          <th>catName</th>
          <th>catImagePath</th>
          <th>Flag</th>
        </tr>
      </thead>
      <tbody>
        { Categary.map(cat => (
          <tr key={cat.catMaster_Id}>
            <td>{cat.catMaster_Id}</td>
            <td>{cat.cat_Id}</td>
            <td>{cat.subCat_Id}</td>
            <td>{cat.cat_Name}</td>
            <td>{cat.cat_Image_Path}</td>
            <td>{cat.flag}</td>
            <td style={{ display: "flex", justifyContent: "space-evenly"}}>
            <Button variant="primary" href={'/displayCategary/'+cat.catMaster_Id}>Display</Button>
            <Button variant="warning" href={'/updateCategary/'+cat.catMaster_Id}>Update</Button>
            <Button variant="danger" href={'/deleteCategary/'+cat.catMaster_Id}>Delete</Button>
            </td>
          </tr>
        ))
        }
      </tbody>
    </Table>
    </div>
  );
}

export default GetCategaryMasters ;
 


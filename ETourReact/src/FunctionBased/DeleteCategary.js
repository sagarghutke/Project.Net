import { useEffect, useState } from "react";
import { Button, Table } from "react-bootstrap";
import { useNavigate, useParams } from "react-router-dom";
 


export default function DeleteCategary(){

    const [categary, setCategary] = useState({});
    const {code} = useParams();
    const navigate = useNavigate();

    useEffect(()=>{
        fetch("http://localhost:5272/api/Categary_Master/"+ code)
        .then(res=>res.json())
        .then(result=>{setCategary(result);});
    }, []);

    const handledelete = (event) =>{
        fetch("http://localhost:5272/api/Categary_Master/"+ code, {
            method:'Delete'
        }).then(res=>res.json()).then(result=>{console.log(result);});
        navigate('/');
    }

    return(
        <div>
        {alert("are you sure for delete this record")}
        <h3>Are your sure for delete this record</h3>
        <Table striped hover bordered>
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
        <tr>
            <td>{categary.catMasterIid}</td>
            <td>{categary.catId}</td>
            <td>{categary.subcatId}</td>
            <td>{categary.catName}</td>
            <td>{categary.catImpPath}</td>
        </tr>
      </tbody>
        </Table>
        <Button variant="primary" onClick={handledelete}>Delete</Button>
        
        </div>
    )
}
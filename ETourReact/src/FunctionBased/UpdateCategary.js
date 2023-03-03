import { useEffect, useState } from "react";
import { Button, Table } from "react-bootstrap";

import { useNavigate, useParams } from "react-router-dom";
import { Form } from "react-router-dom";

export default function UpdateCategary(){

    const [categary, setCategary]=useState({});
    const {code} =useParams();
    let navigate = useNavigate();

    useEffect(()=>{
        fetch("http://localhost:5272/api/categary_master/"+ code).then(res=>res.json())
        .then(result=>{setCategary(result);});
    },{});

    const handleChange = (event) =>{
        const name = event.target.name;
        const value = event.target.value;
        setCategary(values => ({...values, [name]:value}))
    }

    const handleSubmit = (e) =>{
        let data = JSON.stringify(categary);
        fetch("http://localhost:5272/api/categarymasters/"+ code, {
            method:'PUT',
            headers:{'Content-type':'application/json'},
            body: data
        }).then(res=>res.json());
        e.preventDefault();
        navigate('/');
    }

    return(
        <div style={{    display: "flex",justifyContent:"center" }}>
        <form onSubmit={handleSubmit}>
            <Table striped bordered hover style={{width: "fit-content"}}>
            <thead>
            <tr>
              <th>catMasterIid</th>
              <td><input type="text" name="catMasterIid" value={categary.catMasterIid || ""} onChange={handleChange}/></td>
            </tr>
            <tr>
            <th>catId</th>
            <td><input type="text" name="catId" value={categary.catId || ""} onChange={handleChange}/></td>
            </tr>  
            <tr>
            <th>subcatId</th>
            <td><input type="text" name="subcatId" value={categary.subcatId || ""} onChange={handleChange}/></td>
            </tr>  
            <tr>
            <th>catName</th>
            <td><input type="text" name="catName" value={categary.catName || ""} onChange={handleChange}/></td>
            </tr>  
            <tr>
            <th>catImagePath</th>
            <td><input type="text" name="catImagePath" value={categary.catImagePath || ""} onChange={handleChange}/></td>
            </tr>  
            <tr >
            <td></td>
            <td >
            <input type="submit" style={{background: "blanchedalmond", borderRadius: "10px"}}/>
            </td>
            </tr>
          </thead>
        </Table>
            
         

    </form>

    </div>
    )
}
import { useEffect, useState } from "react";
import { Table } from "react-bootstrap";
import { useParams } from "react-router-dom";

export default function DisplayCategory(){
    const[categary, setCategary] = useState({});
    const {code} = useParams();

    useEffect(() => {
        fetch("http://localhost:5272/api/categary_master/"+ code)
        .then(res => res.json()).then(result => {setCategary(result);});
    },{} );

    return(
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
            <td>{categary.catMaster_Id}</td>
            <td>{categary.cat_Id}</td>
            <td>{categary.subcat_Id}</td>
            <td>{categary.catName}</td>
            <td>{categary.catImp_Path}</td>
        </tr>
      </tbody>
        </Table>
    )
}
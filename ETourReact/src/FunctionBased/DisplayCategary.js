import { useEffect, useState } from "react";
import { Button, Card, Table } from "react-bootstrap";
import { useParams } from "react-router-dom";


export default function DisplayCategary(){
  
    const [categary, setCategary] = useState({});
    const {code} = useParams();

    useEffect(() => {
      fetch("https://localhost:7200/api/Category_Master/"+ code)
      .then(res => res.json()).then(result => {setCategary(result);});
    },{} );
    


    return(
   
      <div>
    <Card style={{ width: '18rem' }}>
     
      <Card.Img variant="top" src="/Images/tajmahal.jpg" />
      <Card.Body>
        <Card.Title>{categary.categoryId}</Card.Title>
        <Card.Text>
        {categary.categoryName}
        </Card.Text>
    
        <Button variant="primary" href={'/displayCategary/'+categary.catMasterIid}>Display</Button>
      </Card.Body>
    </Card>
    
        </div>
    )
  }
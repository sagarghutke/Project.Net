import { useEffect, useState } from 'react';
import { Button, Card } from 'react-bootstrap';
import { Outlet } from 'react-router-dom';

function HomePage (){

const [Categary, setCategary] = useState([]);
const [data, setdata] = useState("");

useEffect( () => {
  fetch("https://localhost:7200/api/Category_Master").then(res => res.json())
  .then(result => {
    setCategary(result);
  } 
  );
  }, []);
    
  //const info=Categary.filter((cat)=>cat.SubCat_Id.includes(data));

 return(
    <div>
   
    <div style={{marginLeft:"180px",display:"flex" ,flexWrap:"wrap"}}>
      
        { Categary.map(cat => ( 
            <Card style={{ width: '18rem', margin:"25px" }}>
              

            <Card.Body>
            <img src={cat.categoryImage} class="card-img-top" alt="..." style={{ height: "13rem"}}/>
              <Card.Title>{cat.categoryName}</Card.Title>
              <Card.Text>
              {cat.categoryId}
              {cat.toNewTab}
              </Card.Text>

              {(cat.flag == true) ? (<Button variant="primary" href={"/Itineraries/"+cat.masterId}>Itit</Button>) : (<Button variant="primary" href={"/Search/"+cat.masterId}>Display</Button>) }
            </Card.Body>
          </Card>
        ))
        }
        
        </div>
    </div>
  );
}

export default HomePage ;
 


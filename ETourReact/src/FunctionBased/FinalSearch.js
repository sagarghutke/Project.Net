import { useEffect, useState } from 'react';
import { Button, Card } from 'react-bootstrap';
import { Outlet, useParams } from 'react-router-dom';

function Search (props){

const [Categary, setCategary] = useState([]);
const{code}=useParams();

useEffect( () => {
  fetch("https://localhost:7200/api/Category_Master/"+code).then(res => res.json())
  .then(result => {
    setCategary(result);
  } 
  );
  }, []);

    
  //const info=Categary.filter((cat)=>cat.subcatId.includes(code));

 return(
    <div style={{marginLeft:"180px",display:"flex" ,flexWrap:"wrap"}}>
      {/* //<h1>Search Page</h1> */}
      {/* <h3 style={{}}>Categary Table Data</h3> */}
    
        { Categary.map(cat => ( 
            <Card style={{ width: '18rem', margin:"25px" }}>
            {/* <Card.Img variant="top" src={cat.categoryImage} /> */}
            <img src={cat.categoryImage} class="card-img-top" alt="..." style={{ height: "13rem"}}/>
            <Card.Body>
              <Card.Title>{cat.categoryName}</Card.Title>
              <Card.Text>
              {cat.categoryId}
              </Card.Text>
             
              {(cat.toNewTab == true) ? (<Button variant="primary" href={'/Itineraries/'+cat.masterId}>Itit</Button>) : (<Button variant="primary" href={"/Search/"+cat.masterId}>Display</Button>) }            </Card.Body>
          </Card>
        ))
        }
      
    </div>

    
  );
}

export default Search ;
 


import Button from "react-bootstrap/Button";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Row from "react-bootstrap/Row";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Table } from "react-bootstrap";
import React from 'react';

export default function ContentSearch() 
{
const {code} =useParams();

var curr = new Date();
curr.setDate(curr.getDate() + 1);
var date = curr.toISOString().substring(0,10);


const numberOfDaysToAdd = 120;
var fromdate = curr.setDate(curr.getDate() + numberOfDaysToAdd);
const defaultValue = new Date(fromdate).toISOString().split('T')[0];


const handleSubmit = (e) => {
   e.preventDefault();
  var newdata = {
    DepartureDate: document.getElementById("Fromdate").value,
    EndDate: document.getElementById("Todate").value,
    SinglePersonCost: document.getElementById("CostStart").value,
    NoOfDays: document.getElementById("ToPeriod").value,
  };

  let data = JSON.stringify(newdata);
  
  fetch("https://localhost:7200/api/Search", {
      method: "POST",
      headers: { "Content-type": "application/json" },
      body: data,
    })
      .then((res) => res.json())
      .then((data) => {
        // console.log(data.results);
        const table = document.getElementById("results-table");
        // Clear previous results
        table.innerHTML = "";
    
        if (data.success && data.results && data.results.length > 0) {
          // Create table headers
          const headers = ["CategoryId","Category Name", "Departure Date", "End Date", "Cost", "No.of Days"];
          const headerRow = document.createElement("tr");
          headers.forEach((header) => {
            const th = document.createElement("th");
            th.textContent = header;
            headerRow.appendChild(th);
          });
          table?.appendChild(headerRow);
    
          // Create table rows
          data.results.forEach((result) => {
            //  console.log(result.catMasterId)
            const row = document.createElement("tr");
            Object.values(result).forEach((value) => {
              console.log(result.value)
              const cell = document.createElement("td");
              cell.textContent = value;
              row.appendChild(cell);
            });
            // create a new anchor tag
            const link = document.createElement('a');

            // set the href attribute
            link.href = "/Itineraries/"+(result.masterId);

            // set the text content
            link.textContent = 'Show Details';

            // append the link to the body of the HTML document
            row.appendChild(link);

            table?.appendChild(row);
          });
        } else {
          // Display no results message
          const noResultsRow = document.createElement("tr");
          const noResultsCell = document.createElement("td");
          noResultsCell.colSpan = "5";
          noResultsCell.textContent = "No results found";
          noResultsRow.appendChild(noResultsCell);
          table?.appendChild(noResultsRow);
        }
      });
};

  return (
    <div class="container-xxl col-md-8 mb-0" style={{ backgroundColor: "pink" }}>
       <Form  onSubmit={handleSubmit}>
        <Row className="mb-3">
           <Form.Group as={Col} controlId="Date">
            <h6>
             <Form.Label> Start date </Form.Label>
               <Form.Control type="date" id="Fromdate" defaultValue={date} />
               <Form.Label> End date</Form.Label>
               <Form.Control type="date" id="Todate" defaultValue={defaultValue} />
               <Form.Label> Cost: </Form.Label>
               <Form.Control type="number" id="CostStart" defaultValue={200000} />
              Period:
             <Form.Label> To:</Form.Label>
              <Form.Control type="number" id="ToPeriod" defaultValue={80} />
              <Button type="submit">Submit</Button>
              </h6>
          </Form.Group>
        </Row>
      </Form>
      <div class="table-responsive">
     <table id="results-table" class="table table-bordered table-hover"></table> 
    </div> 
      {/* <table id="results-table" style={{ width: "100%"}}></table> */}
     
     </div>
   
  );

}



 // <div class="container-xxl col-md-10 mb-0" style={{backgroundColor:"pink"}}>
    //   <Form action="a.js" onSubmit={handleSubmit}>
    //     <Row className="mb-3">
    //       <Form.Group as={Col} controlId="Date">
    //         <h6>
    //           Duration:
    //           <Form.Label> Start date </Form.Label>
    //           <Form.Control type="date" id="Fromdate" defaultValue={date} />
    //           <Form.Label> End date</Form.Label>
    //           <Form.Control type="date" id="Todate" defaultValue={defaultValue} />
    //           <Button type="submit">Submit</Button>
    //           Cost:
    //           <Form.Label> </Form.Label>
    //           <Form.Control type="number" id="CostStart"  defaultValue={0}  />
    //           <Form.Label> to</Form.Label>
    //           <Form.Control type="number" id="CostUpto" defaultValue={10000} />
    //             Period:
    //             <Form.Label> From: </Form.Label>
    //             <Form.Control type="number" id="FromPeriod" defaultValue={0} />
    //             <Form.Label> To:</Form.Label>
    //             <Form.Control type="number" id="ToPeriod" defaultValue={20} />
    //           <Button type="submit">Submit</Button>
    //            <table id="results-table"></table>
    //         </h6>
    //       </Form.Group>
    //     </Row>
    //   </Form>
    //   <table id="results-table"></table>
    // </div>




// import Button from "react-bootstrap/Button";
// import Col from "react-bootstrap/Col";
// import Form from "react-bootstrap/Form";
// import Row from "react-bootstrap/Row";
// import React from "react";

// export default function ContentSearchTrial() {

  

//   return (
    
//       <div class="container-xxl col-md-6 mb-0" style={{ backgroundColor: "pink" }}>
//   <Form  onSubmit={handleSubmit}>
//     <Row className="mb-3">
//       <Form.Group as={Col} controlId="Date">
//         <h6>
//           <Form.Label> Start date </Form.Label>
//           <Form.Control type="date" id="Fromdate" defaultValue={date} />
//           <Form.Label> End date</Form.Label>
//           <Form.Control type="date" id="Todate" defaultValue={defaultValue} />
//           {/* <Button type="submit">Submit</Button> */}
//           <Form.Label> Cost: </Form.Label>
//           <Form.Control type="number" id="CostStart" defaultValue={0} />
//           Period:
//           <Form.Label> To:</Form.Label>
//           <Form.Control type="number" id="ToPeriod" defaultValue={20} />
//           <Button type="submit">Submit</Button>
//         </h6> <table id="results-table"></table>
//       </Form.Group>
//     </Row>
//   </Form>

 
// </div>

//   );
// }
import { Component } from "react";

export default class PostCategaryMasters extends Component{

    state = {
        message : ""
    }
    onCreateEmployee = () => {
        let Categary = {
            "catId" : this.refs.catId.value,
            "subcatId" : this.refs.subcatId.value,
            "catName" : this.refs.catName.value,
            "catImgPath" : this.refs.catImgPath.value
        }; 

        let categary = JSON.stringify(Categary);
        fetch("http://localhost:5281/api/categarymasters",{
           method: 'POST',
           headers: {'Content-type':'application/json'},
           body: categary 
        }).then(res => res.json()).then(result => {
            if(result){ this.setState({message:'New Categary is created'});
        alert(this.setState.message);}
        })
    }

    render(){
        return(
            <div>
                <h2>Create Categary......</h2>
                <p><label>catId : <input type="text" ref="catId"></input></label></p>
                <p><label>subcatId : <input type="text" ref="subcatId"></input></label></p>
                <p><label>catName : <input type="text" ref="catName"></input></label></p>
                <p><label>catImagePath : <input type="text" ref="catImgPath"></input></label></p>
                <button onClick={this.onCreateEmployee}>Create</button>
                
            </div>
        );
    }
}
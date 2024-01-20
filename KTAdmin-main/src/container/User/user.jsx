import  { FC, Fragment, useState,useEffect } from 'react';
import { Card, Col, Row } from 'react-bootstrap';
import Pageheader from '../../components/pageheader/pageheader';
//import { Columns, Data, Data1, Data2, Data3 } from '../griddata'
import { Grid } from "gridjs-react";
import "gridjs/dist/theme/mermaid.css"; 
import {Data1} from '../tables/gridjstables/griddata'
import { getDataService } from '../../services/service';

const User= () => {

    const [allUser,setAllUser] = useState([]);

    useEffect(() => {
        debugger;    
        LoadAllUser();
    }, []);

    const LoadAllUser = async ()=>{
        const result = await getDataService('api/User/GetAllUser');
        console.log(result);
        setAllUser(result);
    }

    return (
        <Fragment>
            <Pageheader title="Users" heading="Tables" active="Grid Js" />
            <Row>
                <Col xl={12}>
                    <Card className="custom-card">
                        {/* <Card.Header>
                            <Card.Title>
                                Users 
                            </Card.Title>
                        </Card.Header> */}
                        <Card.Body>
                            <div id="grid-loading">
                                <Grid
                                    data={allUser}
                                    sort={true}
                                    search={true}
                                    columns={['userId','userName', 'Name', 'Email', 'Mobile']} pagination={{
                                        limit: 10,
                                    }}
                                    loading={true} />
                            </div>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
            </Fragment>
    );
};
export default User;
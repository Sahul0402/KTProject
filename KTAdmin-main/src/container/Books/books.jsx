import  { FC, Fragment, useState,useEffect } from 'react';
import { Card, Col, Row } from 'react-bootstrap';
import Pageheader from '../../components/pageheader/pageheader'
import { Grid } from "gridjs-react";
import "gridjs/dist/theme/mermaid.css"; 
import { getDataService } from '../../services/service';

const Books= () => {

    const [allBooks,setAllBooks] = useState([]);

    useEffect(() => {
        debugger;    
        LoadAllBooks();
    }, []);

    const LoadAllBooks = async ()=>{
        const result = await getDataService('api/Book/GetAllBooks');
        console.log(result);
        setAllBooks(result);
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
                                    data={allBooks}
                                    sort={true}
                                    search={true}
                                    columns={['bookId','bookName', 'Name']} pagination={{
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
export default Books;
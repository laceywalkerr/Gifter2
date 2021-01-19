import React, { useState } from 'react';
import { Form, Input } from 'reactstrap';

const PostSearch = () => {
    const [searchTerm, setSearchTerm] = useState("");

    const handleSubmit = (e) => {
        e.preventDefault();
        fetch(`/api/post/search?criterion=${searchTerm}`)
            .then(res => res.json())
            .then(searchResults => console.log(searchResults));
    }

    return (
        <Form onSubmit={handleSubmit}>
            <Input placeholder="Search by Title" onChange={e => setSearchTerm(e.target.value)} />
        </Form>
    );
};

export default PostSearch;
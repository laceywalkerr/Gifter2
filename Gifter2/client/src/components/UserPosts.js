import React, { useEffect } from "react";
import { useParams } from 'react-router-dom';


const UserPosts = () => {
    const { userId } = useParams();

    useEffect(() => {
        fetch(`/api/post/getbyuser/${userId}`)
            .then(res => res.json())
            .then(posts => console.log(posts));
    }, []);

    return (
        <div>
            <h1>User Posts</h1>
            <h4>{userId}</h4>
        </div>
    );
};



export default UserPosts;
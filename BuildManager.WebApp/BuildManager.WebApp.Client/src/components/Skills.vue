<template>
    <div>
        <h2> Skills </h2>
        <div>
            <b-dropdown  id="skill-dropdown" text="Skills..." class="m-md-2">
                <b-dropdown-item v-for="skill in skills" :key="skill.skillid">{{skill.name}}</b-dropdown-item>
            </b-dropdown>
        </div>
         <ul>
             <li>
                 <h3></h3>
             </li>
         </ul>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    data(){
        return {
            skills: []
        };
    },
    async created() {
        try {
            const response = await axios.get('http://localhost:5083/api/skill')
            this.skills = response.data;
            console.log(response.data);
        } catch (error) {
            console.error(error);
        }
    }
};

</script>

            

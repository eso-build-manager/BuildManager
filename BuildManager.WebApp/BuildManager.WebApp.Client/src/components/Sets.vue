<template>
	<div>
		<h2> Builds </h2>
		<ul>
			<li v-for="set in sets" :key="set.SetId">
				<h3>{{set.setName}} </h3>

			</li>
		</ul>
	</div>
</template>
<script>
import axios from 'axios';

export default{
	data(){
		return{
			sets: []
		};
	},
	async created() {
		try {
			const response = await axios.get('http://localhost:5083/api/setlist');
			this.sets = response.data;
			console.log(response.data);
		} catch (error)	{
			console.error(error);
		}
	}
};

</script>
 